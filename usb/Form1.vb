Imports System.Diagnostics
Imports System.IO
Imports System.Management
Imports System.Media
Imports System.Reflection.Emit
Imports System.Security.Principal
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1

    Dim alert As Boolean = False
    Dim completedTime As String = ""
    Private isCopyInProgress As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make sure app is being ran with admin privileges
        EnsureRunningAsAdmin()

        ' Set the default values
        FileSystemComboBox.SelectedItem = "NTFS"
        ConcurrencyComboBox.SelectedItem = "4"

        ' Clear the list of drives
        DestinationCheckedListBox.Items.Clear()

        ' Get all ready removable drives (USBs)
        Dim usbDrives = DriveInfo.GetDrives().Where(
            Function(d) d.DriveType = DriveType.Removable AndAlso d.IsReady
        ).ToList()

        ' Add each drive to the CheckedListBox
        For Each drive In usbDrives
            DestinationCheckedListBox.Items.Add(drive.Name & " (" & drive.VolumeLabel & ")", True)
        Next
    End Sub

    Private Sub EnsureRunningAsAdmin()
        Dim wi = WindowsIdentity.GetCurrent()
        Dim wp = New WindowsPrincipal(wi)
        Dim isAdmin As Boolean = wp.IsInRole(WindowsBuiltInRole.Administrator)

        If Not isAdmin Then
            ' Restart the app as admin
            Dim proc As New ProcessStartInfo()
            proc.FileName = Process.GetCurrentProcess().MainModule.FileName
            proc.UseShellExecute = True
            proc.Verb = "runas" ' run as admin

            Try
                Process.Start(proc)
            Catch ex As Exception
                MessageBox.Show("This application must be run as administrator.")
            End Try
            ' Close current instance
            Environment.Exit(0)
        End If
    End Sub

    Private Sub SourceButton_Click(sender As Object, e As EventArgs) Handles SourceButton.Click
        ' Create and configure the OpenFileDialog
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        openFileDialog.Multiselect = True
        openFileDialog.Title = "Select Files from Desktop"
        openFileDialog.Filter = "All files (*.*)|*.*"

        ' Show the dialog and check if user selected files
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Join file paths with line breaks and show in RichTextBox
            SourceRichTextBox.Text = String.Join(Environment.NewLine, openFileDialog.FileNames)
        End If
    End Sub

    Private Async Sub CopyButton_Click(sender As Object, e As EventArgs) Handles CopyButton.Click
        ' Disable buttons when copying is in progress
        isCopyInProgress = True
        SourceButton.Enabled = False
        FileSystemComboBox.Enabled = False
        LabelTextBox.Enabled = False
        RefreshDrivesButton.Enabled = False
        DestinationCheckedListBox.Enabled = False
        ConcurrencyComboBox.Enabled = False
        CopyButton.Enabled = False

        ' Reset the progress bar
        ProgressBar.Minimum = 0
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0

        ' Start timer
        Dim sw As New Stopwatch()
        sw.Start()

        ' Await the async method directly
        Await Task.Run(Function() PerformFormatAndCopy())

        ' Stop timer and calculate time in minutes
        sw.Stop()
        Dim completedTime As String = String.Format("{0:0.0} minutes", sw.Elapsed.TotalMinutes)

        ' Formatting and copying has completed
        ProgressLabel.Text = "Done: " & completedTime

        ' Re-enable buttons
        isCopyInProgress = False
        SourceButton.Enabled = True
        FileSystemComboBox.Enabled = True
        LabelTextBox.Enabled = True
        RefreshDrivesButton.Enabled = True
        DestinationCheckedListBox.Enabled = True
        ConcurrencyComboBox.Enabled = True
        CopyButton.Enabled = True
    End Sub


    Private Async Function PerformFormatAndCopy() As Task
        Try
            ' Get all the removable drives
            Dim usbDrives = DriveInfo.GetDrives().Where(
                Function(d) d.DriveType = DriveType.Removable AndAlso d.IsReady
            ).ToList()

            ' Stop if no removable drives found
            If usbDrives.Count = 0 Then
                Invoke(Sub() MessageBox.Show("No USB drives detected."))
                Exit Function
            End If

            ' Only use the drives that are checked in the drive list
            Dim selectedLetters As New HashSet(Of String)(
                    DestinationCheckedListBox.CheckedItems.
                        Cast(Of String)().
                        Select(Function(item) item.Substring(0, 3).ToUpper()) ' Ex: "E:\"
                )

                ' Remove any drive from usbDrives that is not in the checked items
                usbDrives = usbDrives.Where(
                    Function(d) selectedLetters.Contains(d.Name.ToUpper())
                ).ToList()

            ' Show message if none of the selected drives are currently available
            If usbDrives.Count = 0 Then
                Invoke(Sub() MessageBox.Show("No USB drives were selected."))
                Exit Function
            End If

            Dim fileSystem As String = String.Empty
            Dim volumeLabel As String = String.Empty
            Invoke(Sub()
                       fileSystem = FileSystemComboBox.Text
                       volumeLabel = LabelTextBox.Text
                       ProgressBar.Minimum = 0
                       ProgressBar.Maximum = usbDrives.Count
                       ProgressBar.Value = 0
                   End Sub)

            Dim successfulFormats As Integer = 0

            For Each drive In usbDrives
                Dim driveLetter = drive.RootDirectory.FullName.TrimEnd("\"c)

                Try
                    ' Create the command to format the drive and add a drive letter
                    Dim formatCmd = $"format {driveLetter} /FS:{fileSystem} /Q /Y"
                    Dim psi As New ProcessStartInfo("cmd.exe", "/C " & formatCmd) With {
                    .UseShellExecute = False,
                    .Verb = "runas",
                    .CreateNoWindow = True
                }

                    ' Formatting has started
                    ProgressLabel.Text = "Formatting"

                    ' Format the drive
                    Using proc As Process = Process.Start(psi)
                        proc.WaitForExit()

                        ' Check if drive format was successful
                        If proc.ExitCode = 0 Then
                            ' Create the command to label the drive
                            Dim labelCmd = $"label {driveLetter} {volumeLabel}"
                            Dim labelPsi As New ProcessStartInfo("cmd.exe", "/C " & labelCmd) With {
                                .UseShellExecute = False,
                                .Verb = "runas",
                                .CreateNoWindow = True
                            }

                            ' Label the drive
                            Process.Start(labelPsi)

                            ' Increase the progress bar countif format and label were successful
                            successfulFormats += 1
                            Invoke(Sub() ProgressBar.Value = successfulFormats)
                        Else
                            Invoke(Sub() MessageBox.Show($"Format failed on drive {driveLetter} with exit code: {proc.ExitCode}"))
                        End If
                    End Using
                Catch ex As Exception
                    Invoke(Sub() MessageBox.Show($"Failed to format {driveLetter}: {ex.Message}"))
                End Try
            Next

            ' Progress bar is based on number of removable drives and number of files being copied
            Dim sourceFiles = New String() {}
            Invoke(Sub()
                       sourceFiles = SourceRichTextBox.Lines
                       ProgressBar.Minimum = 0
                       ProgressBar.Maximum = sourceFiles.Length * usbDrives.Count
                       ProgressBar.Value = 0
                   End Sub)

            ' Stop if no files were selected to copy
            If sourceFiles.Length = 0 Then
                Invoke(Sub() MessageBox.Show("No source files to copy."))
                Exit Function
            End If

            ' Copy the files to each removable drive
            Dim maxConcurrency As Integer = 1
            Invoke(Sub()
                       Integer.TryParse(ConcurrencyComboBox.Text, maxConcurrency)
                       If maxConcurrency < 1 Then maxConcurrency = 1
                   End Sub)

            Dim semaphore As New SemaphoreSlim(maxConcurrency)
            Dim copyTasks As New List(Of Task)

            For Each drive In usbDrives
                Dim driveCopyTask As Task = Task.Run(Async Function()
                                                         Await semaphore.WaitAsync()
                                                         Try
                                                             For Each filePath In sourceFiles
                                                                 Dim fileInfo As New FileInfo(filePath)
                                                                 If fileInfo.Exists Then
                                                                     Try
                                                                         Invoke(Sub() ProgressLabel.Text = $"Copying")
                                                                         Dim destPath = Path.Combine(drive.RootDirectory.FullName, Path.GetFileName(filePath))
                                                                         File.Copy(fileInfo.FullName, destPath, True)
                                                                     Catch ex As Exception
                                                                         Invoke(Sub() MessageBox.Show($"Failed to copy: {filePath} to {drive.Name}: {ex.Message}"))
                                                                     End Try
                                                                 Else
                                                                     Invoke(Sub() MessageBox.Show("File not found: " & fileInfo.FullName))
                                                                 End If
                                                                 Invoke(Sub() ProgressBar.Value += 1)
                                                             Next
                                                         Finally
                                                             semaphore.Release()
                                                         End Try
                                                     End Function)
                copyTasks.Add(driveCopyTask)
            Next

            Await Task.WhenAll(copyTasks)


            ' Show the updated volume labels
            DestinationCheckedListBox.Items.Clear() ' Clear all items first
            usbDrives = DriveInfo.GetDrives().Where(
                Function(d) d.DriveType = DriveType.Removable AndAlso d.IsReady
            ).ToList()
            For Each drive In usbDrives
                DestinationCheckedListBox.Items.Add(drive.Name & " (" & drive.VolumeLabel & ")", True)
            Next

            ' Check if the alert sound is enabled
            If alert Then
                ' Play the alert sound
                Invoke(Sub()
                           Dim player As New SoundPlayer(My.Resources.Ring10)
                           player.Play()
                       End Sub)
            End If

        Catch ex As Exception
            Invoke(Sub() MessageBox.Show("Error: " & ex.Message))
        End Try
    End Function

    Private Sub AlertButton_Click(sender As Object, e As EventArgs) Handles AlertButton.Click
        ' Toggle the alert when clicked
        alert = Not alert
        AlertButton.BackgroundImage = If(alert, My.Resources.sound_on, My.Resources.sound_off)
    End Sub

    Private Sub LabelTextBox_TextChanged(sender As Object, e As EventArgs) Handles LabelTextBox.TextChanged
        ' Prevent volume label from being too long
        If FileSystemComboBox.Text = "NTFS" AndAlso LabelTextBox.Text.Length > 32 Then
            MessageBox.Show("The volume label cannot be longer" & vbCrLf & "than 32 characters for NTFS", "Label Too Long", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LabelTextBox.Text = LabelTextBox.Text.Substring(0, 32)
            LabelTextBox.SelectionStart = LabelTextBox.Text.Length ' Maintain cursor position
        ElseIf (FileSystemComboBox.Text = "exFAT" OrElse
            FileSystemComboBox.Text = "FAT16" OrElse
            FileSystemComboBox.Text = "FAT32") AndAlso
            LabelTextBox.Text.Length > 11 Then
            MessageBox.Show("The volume label cannot be longer" & vbCrLf & "than 11 characters for FAT", "Label Too Long", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LabelTextBox.Text = LabelTextBox.Text.Substring(0, 11)
            LabelTextBox.SelectionStart = LabelTextBox.Text.Length ' Maintain cursor position
        End If
    End Sub

    Private Sub FileSystemComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FileSystemComboBox.SelectedIndexChanged
        ' Prevent volume label from being too long
        If FileSystemComboBox.Text = "NTFS" AndAlso LabelTextBox.Text.Length > 32 Then
            MessageBox.Show("The volume label cannot be longer" & vbCrLf & "than 32 characters for NTFS", "Label Too Long", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LabelTextBox.Text = LabelTextBox.Text.Substring(0, 32)
            LabelTextBox.SelectionStart = LabelTextBox.Text.Length ' Maintain cursor position
        ElseIf (FileSystemComboBox.Text = "exFAT" OrElse
            FileSystemComboBox.Text = "FAT16" OrElse
            FileSystemComboBox.Text = "FAT32") AndAlso
            LabelTextBox.Text.Length > 11 Then
            MessageBox.Show("The volume label cannot be longer" & vbCrLf & "than 11 characters for FAT", "Label Too Long", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LabelTextBox.Text = LabelTextBox.Text.Substring(0, 11)
            LabelTextBox.SelectionStart = LabelTextBox.Text.Length ' Maintain cursor position
        End If
    End Sub

    Private Sub FormatProgressLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ConcurrencyComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ConcurrencyComboBox.SelectedIndexChanged
        Dim concurrencyNumber As String = ConcurrencyComboBox.SelectedItem
        If ConcurrencyComboBox.SelectedItem = "1" Then
            ConcurrencyBottomLabel.Text = "drive at a time"
        Else
            ConcurrencyBottomLabel.Text = "drives at a time"
        End If
    End Sub

    Private Sub RefreshDrivesButton_Click(sender As Object, e As EventArgs) Handles RefreshDrivesButton.Click
        ' Clear the list of drives
        DestinationCheckedListBox.Items.Clear()

        ' Get all ready removable drives (USBs)
        Dim usbDrives = DriveInfo.GetDrives().Where(
            Function(d) d.DriveType = DriveType.Removable AndAlso d.IsReady
        ).ToList()

        ' Add each drive to the CheckedListBox
        For Each drive In usbDrives
            DestinationCheckedListBox.Items.Add(drive.Name & " (" & drive.VolumeLabel & ")", True)
        Next

        ' Set the progress label back to ready
        If ProgressLabel.Text IsNot "Ready" Then
            ProgressLabel.Text = "Ready"
        End If
    End Sub
End Class