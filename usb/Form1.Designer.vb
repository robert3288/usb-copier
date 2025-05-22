<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.LabelTextBox = New System.Windows.Forms.TextBox()
        Me.LabelLabel = New System.Windows.Forms.Label()
        Me.FileSystemComboBox = New System.Windows.Forms.ComboBox()
        Me.FileSystemLabel = New System.Windows.Forms.Label()
        Me.SourceGroupBox = New System.Windows.Forms.GroupBox()
        Me.SourceRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.SourceButton = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.ProgressLabel = New System.Windows.Forms.Label()
        Me.CopyButton = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.AlertButton = New System.Windows.Forms.Button()
        Me.ConcurrencyComboBox = New System.Windows.Forms.ComboBox()
        Me.ConcurrencyTopLabel = New System.Windows.Forms.Label()
        Me.DestinationGroupBox = New System.Windows.Forms.GroupBox()
        Me.RefreshDrivesButton = New System.Windows.Forms.Button()
        Me.DestinationCheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.ConcurrencyBottomLabel = New System.Windows.Forms.Label()
        Me.ConcurrencyBGLabel = New System.Windows.Forms.Label()
        Me.ProgressBarBGLabel = New System.Windows.Forms.Label()
        Me.SourceGroupBox.SuspendLayout()
        Me.DestinationGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelTextBox
        '
        Me.LabelTextBox.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTextBox.Location = New System.Drawing.Point(245, 30)
        Me.LabelTextBox.Name = "LabelTextBox"
        Me.LabelTextBox.Size = New System.Drawing.Size(245, 27)
        Me.LabelTextBox.TabIndex = 7
        '
        'LabelLabel
        '
        Me.LabelLabel.AutoSize = True
        Me.LabelLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLabel.Location = New System.Drawing.Point(198, 34)
        Me.LabelLabel.Name = "LabelLabel"
        Me.LabelLabel.Size = New System.Drawing.Size(46, 19)
        Me.LabelLabel.TabIndex = 6
        Me.LabelLabel.Text = "Label"
        Me.LabelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FileSystemComboBox
        '
        Me.FileSystemComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FileSystemComboBox.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileSystemComboBox.FormattingEnabled = True
        Me.FileSystemComboBox.Items.AddRange(New Object() {"exFAT", "FAT16", "FAT32", "NTFS"})
        Me.FileSystemComboBox.Location = New System.Drawing.Point(100, 30)
        Me.FileSystemComboBox.Name = "FileSystemComboBox"
        Me.FileSystemComboBox.Size = New System.Drawing.Size(77, 27)
        Me.FileSystemComboBox.TabIndex = 5
        '
        'FileSystemLabel
        '
        Me.FileSystemLabel.AutoSize = True
        Me.FileSystemLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileSystemLabel.Location = New System.Drawing.Point(10, 34)
        Me.FileSystemLabel.Name = "FileSystemLabel"
        Me.FileSystemLabel.Size = New System.Drawing.Size(89, 19)
        Me.FileSystemLabel.TabIndex = 4
        Me.FileSystemLabel.Text = "File System"
        Me.FileSystemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SourceGroupBox
        '
        Me.SourceGroupBox.Controls.Add(Me.SourceRichTextBox)
        Me.SourceGroupBox.Controls.Add(Me.SourceButton)
        Me.SourceGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SourceGroupBox.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SourceGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.SourceGroupBox.Name = "SourceGroupBox"
        Me.SourceGroupBox.Size = New System.Drawing.Size(505, 128)
        Me.SourceGroupBox.TabIndex = 0
        Me.SourceGroupBox.TabStop = False
        Me.SourceGroupBox.Text = "SOURCE"
        '
        'SourceRichTextBox
        '
        Me.SourceRichTextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SourceRichTextBox.Location = New System.Drawing.Point(111, 28)
        Me.SourceRichTextBox.Name = "SourceRichTextBox"
        Me.SourceRichTextBox.ReadOnly = True
        Me.SourceRichTextBox.Size = New System.Drawing.Size(379, 86)
        Me.SourceRichTextBox.TabIndex = 2
        Me.SourceRichTextBox.TabStop = False
        Me.SourceRichTextBox.Text = ""
        Me.SourceRichTextBox.WordWrap = False
        '
        'SourceButton
        '
        Me.SourceButton.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SourceButton.Location = New System.Drawing.Point(14, 30)
        Me.SourceButton.Name = "SourceButton"
        Me.SourceButton.Size = New System.Drawing.Size(91, 84)
        Me.SourceButton.TabIndex = 1
        Me.SourceButton.Text = "Select Files"
        Me.SourceButton.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(255, 374)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(159, 19)
        Me.ProgressBar.TabIndex = 17
        '
        'ProgressLabel
        '
        Me.ProgressLabel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ProgressLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgressLabel.Location = New System.Drawing.Point(255, 343)
        Me.ProgressLabel.Name = "ProgressLabel"
        Me.ProgressLabel.Size = New System.Drawing.Size(159, 25)
        Me.ProgressLabel.TabIndex = 16
        Me.ProgressLabel.Text = "Ready"
        Me.ProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ProgressLabel.UseCompatibleTextRendering = True
        '
        'CopyButton
        '
        Me.CopyButton.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyButton.Location = New System.Drawing.Point(427, 338)
        Me.CopyButton.Name = "CopyButton"
        Me.CopyButton.Size = New System.Drawing.Size(90, 61)
        Me.CopyButton.TabIndex = 18
        Me.CopyButton.Text = "Copy"
        Me.CopyButton.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 1000
        Me.ToolTip1.ReshowDelay = 100
        '
        'AlertButton
        '
        Me.AlertButton.BackgroundImage = Global.usb.My.Resources.Resources.sound_off
        Me.AlertButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.AlertButton.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AlertButton.Location = New System.Drawing.Point(12, 338)
        Me.AlertButton.Name = "AlertButton"
        Me.AlertButton.Size = New System.Drawing.Size(72, 61)
        Me.AlertButton.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.AlertButton, "Play a sound when the job is finished")
        Me.AlertButton.UseVisualStyleBackColor = True
        '
        'ConcurrencyComboBox
        '
        Me.ConcurrencyComboBox.BackColor = System.Drawing.SystemColors.Window
        Me.ConcurrencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConcurrencyComboBox.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConcurrencyComboBox.FormattingEnabled = True
        Me.ConcurrencyComboBox.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.ConcurrencyComboBox.Location = New System.Drawing.Point(196, 343)
        Me.ConcurrencyComboBox.Name = "ConcurrencyComboBox"
        Me.ConcurrencyComboBox.Size = New System.Drawing.Size(35, 27)
        Me.ConcurrencyComboBox.TabIndex = 13
        '
        'ConcurrencyTopLabel
        '
        Me.ConcurrencyTopLabel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ConcurrencyTopLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConcurrencyTopLabel.Location = New System.Drawing.Point(98, 346)
        Me.ConcurrencyTopLabel.Name = "ConcurrencyTopLabel"
        Me.ConcurrencyTopLabel.Size = New System.Drawing.Size(133, 26)
        Me.ConcurrencyTopLabel.TabIndex = 12
        Me.ConcurrencyTopLabel.Text = "Copy files to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.ConcurrencyTopLabel.UseCompatibleTextRendering = True
        '
        'DestinationGroupBox
        '
        Me.DestinationGroupBox.Controls.Add(Me.RefreshDrivesButton)
        Me.DestinationGroupBox.Controls.Add(Me.LabelTextBox)
        Me.DestinationGroupBox.Controls.Add(Me.LabelLabel)
        Me.DestinationGroupBox.Controls.Add(Me.DestinationCheckedListBox)
        Me.DestinationGroupBox.Controls.Add(Me.FileSystemComboBox)
        Me.DestinationGroupBox.Controls.Add(Me.FileSystemLabel)
        Me.DestinationGroupBox.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DestinationGroupBox.Location = New System.Drawing.Point(12, 146)
        Me.DestinationGroupBox.Name = "DestinationGroupBox"
        Me.DestinationGroupBox.Size = New System.Drawing.Size(505, 180)
        Me.DestinationGroupBox.TabIndex = 3
        Me.DestinationGroupBox.TabStop = False
        Me.DestinationGroupBox.Text = "DESTINATION"
        '
        'RefreshDrivesButton
        '
        Me.RefreshDrivesButton.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefreshDrivesButton.Location = New System.Drawing.Point(14, 74)
        Me.RefreshDrivesButton.Name = "RefreshDrivesButton"
        Me.RefreshDrivesButton.Size = New System.Drawing.Size(85, 94)
        Me.RefreshDrivesButton.TabIndex = 8
        Me.RefreshDrivesButton.Text = "Refresh"
        Me.RefreshDrivesButton.UseVisualStyleBackColor = True
        '
        'DestinationCheckedListBox
        '
        Me.DestinationCheckedListBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DestinationCheckedListBox.FormattingEnabled = True
        Me.DestinationCheckedListBox.HorizontalScrollbar = True
        Me.DestinationCheckedListBox.Location = New System.Drawing.Point(111, 74)
        Me.DestinationCheckedListBox.Name = "DestinationCheckedListBox"
        Me.DestinationCheckedListBox.Size = New System.Drawing.Size(379, 94)
        Me.DestinationCheckedListBox.TabIndex = 9
        Me.DestinationCheckedListBox.ThreeDCheckBoxes = True
        '
        'ConcurrencyBottomLabel
        '
        Me.ConcurrencyBottomLabel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ConcurrencyBottomLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConcurrencyBottomLabel.Location = New System.Drawing.Point(98, 368)
        Me.ConcurrencyBottomLabel.Name = "ConcurrencyBottomLabel"
        Me.ConcurrencyBottomLabel.Size = New System.Drawing.Size(133, 25)
        Me.ConcurrencyBottomLabel.TabIndex = 14
        Me.ConcurrencyBottomLabel.Text = "drives at a time"
        Me.ConcurrencyBottomLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ConcurrencyBottomLabel.UseCompatibleTextRendering = True
        '
        'ConcurrencyBGLabel
        '
        Me.ConcurrencyBGLabel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ConcurrencyBGLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ConcurrencyBGLabel.Location = New System.Drawing.Point(90, 338)
        Me.ConcurrencyBGLabel.Name = "ConcurrencyBGLabel"
        Me.ConcurrencyBGLabel.Size = New System.Drawing.Size(152, 61)
        Me.ConcurrencyBGLabel.TabIndex = 11
        '
        'ProgressBarBGLabel
        '
        Me.ProgressBarBGLabel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ProgressBarBGLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProgressBarBGLabel.Location = New System.Drawing.Point(248, 338)
        Me.ProgressBarBGLabel.Name = "ProgressBarBGLabel"
        Me.ProgressBarBGLabel.Size = New System.Drawing.Size(173, 61)
        Me.ProgressBarBGLabel.TabIndex = 15
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(529, 411)
        Me.Controls.Add(Me.ConcurrencyComboBox)
        Me.Controls.Add(Me.ConcurrencyBottomLabel)
        Me.Controls.Add(Me.DestinationGroupBox)
        Me.Controls.Add(Me.CopyButton)
        Me.Controls.Add(Me.ProgressLabel)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.AlertButton)
        Me.Controls.Add(Me.SourceGroupBox)
        Me.Controls.Add(Me.ConcurrencyTopLabel)
        Me.Controls.Add(Me.ConcurrencyBGLabel)
        Me.Controls.Add(Me.ProgressBarBGLabel)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "USB Copier"
        Me.SourceGroupBox.ResumeLayout(False)
        Me.DestinationGroupBox.ResumeLayout(False)
        Me.DestinationGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SourceGroupBox As GroupBox
    Friend WithEvents SourceButton As Button
    Friend WithEvents SourceRichTextBox As RichTextBox
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents ProgressLabel As Label
    Friend WithEvents CopyButton As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents LabelTextBox As TextBox
    Friend WithEvents LabelLabel As Label
    Friend WithEvents FileSystemComboBox As ComboBox
    Friend WithEvents FileSystemLabel As Label
    Friend WithEvents AlertButton As Button
    Friend WithEvents DestinationGroupBox As GroupBox
    Friend WithEvents DestinationCheckedListBox As CheckedListBox
    Friend WithEvents ConcurrencyComboBox As ComboBox
    Friend WithEvents ConcurrencyTopLabel As Label
    Friend WithEvents RefreshDrivesButton As Button
    Friend WithEvents ConcurrencyBottomLabel As Label
    Friend WithEvents ConcurrencyBGLabel As Label
    Friend WithEvents ProgressBarBGLabel As Label
End Class
