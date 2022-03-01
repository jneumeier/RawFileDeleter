<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPhotoFolder = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnCleanUp = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRawFormat = New System.Windows.Forms.TextBox()
        Me.txtJpegExtension = New System.Windows.Forms.TextBox()
        Me.txtVideoFormat = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnOrganize = New System.Windows.Forms.Button()
        Me.txtNewFolderName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(336, 18)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Enter root folder with images/videos:"
        '
        'txtPhotoFolder
        '
        Me.txtPhotoFolder.Location = New System.Drawing.Point(15, 58)
        Me.txtPhotoFolder.Name = "txtPhotoFolder"
        Me.txtPhotoFolder.Size = New System.Drawing.Size(270, 20)
        Me.txtPhotoFolder.TabIndex = 0
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(300, 55)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnCleanUp
        '
        Me.btnCleanUp.Location = New System.Drawing.Point(99, 328)
        Me.btnCleanUp.Name = "btnCleanUp"
        Me.btnCleanUp.Size = New System.Drawing.Size(186, 23)
        Me.btnCleanUp.TabIndex = 8
        Me.btnCleanUp.Text = "&Clean Up RAW Files"
        Me.btnCleanUp.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(99, 370)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(186, 23)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "RAW format"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(142, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "jpeg extension"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(268, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Video format"
        '
        'txtRawFormat
        '
        Me.txtRawFormat.Location = New System.Drawing.Point(15, 159)
        Me.txtRawFormat.Name = "txtRawFormat"
        Me.txtRawFormat.Size = New System.Drawing.Size(100, 20)
        Me.txtRawFormat.TabIndex = 3
        Me.txtRawFormat.Text = ".RAF"
        '
        'txtJpegExtension
        '
        Me.txtJpegExtension.Location = New System.Drawing.Point(145, 159)
        Me.txtJpegExtension.Name = "txtJpegExtension"
        Me.txtJpegExtension.Size = New System.Drawing.Size(100, 20)
        Me.txtJpegExtension.TabIndex = 4
        Me.txtJpegExtension.Text = ".JPG"
        '
        'txtVideoFormat
        '
        Me.txtVideoFormat.Location = New System.Drawing.Point(271, 159)
        Me.txtVideoFormat.Name = "txtVideoFormat"
        Me.txtVideoFormat.Size = New System.Drawing.Size(100, 20)
        Me.txtVideoFormat.TabIndex = 5
        Me.txtVideoFormat.Text = ".MOV"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(184, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Enter the extensions of each file type:"
        '
        'btnOrganize
        '
        Me.btnOrganize.Location = New System.Drawing.Point(99, 284)
        Me.btnOrganize.Name = "btnOrganize"
        Me.btnOrganize.Size = New System.Drawing.Size(186, 23)
        Me.btnOrganize.TabIndex = 7
        Me.btnOrganize.Text = "&Organize Files Into Folders"
        Me.btnOrganize.UseVisualStyleBackColor = True
        '
        'txtNewFolderName
        '
        Me.txtNewFolderName.Location = New System.Drawing.Point(15, 230)
        Me.txtNewFolderName.Name = "txtNewFolderName"
        Me.txtNewFolderName.Size = New System.Drawing.Size(270, 20)
        Me.txtNewFolderName.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 211)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(185, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Enter new root folder name, if desired:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(402, 473)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNewFolderName)
        Me.Controls.Add(Me.btnOrganize)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtVideoFormat)
        Me.Controls.Add(Me.txtJpegExtension)
        Me.Controls.Add(Me.txtRawFormat)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnCleanUp)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtPhotoFolder)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtPhotoFolder As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents btnCleanUp As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRawFormat As TextBox
    Friend WithEvents txtJpegExtension As TextBox
    Friend WithEvents txtVideoFormat As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnOrganize As Button
    Friend WithEvents txtNewFolderName As TextBox
    Friend WithEvents Label6 As Label
End Class
