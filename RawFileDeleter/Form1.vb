' ****************************************************************
' Name:          John Neumeier
' Date started:  01/30/22
' Date updated:  03/03/22
' Abstract:      Windows Forms Application that helps the user
'                delete all RAW image files in a folder that do
'                not have an accompanying JPG file of same name.
' ****************************************************************



' -----------------------------------------------------------
' Still to implement

'- Proper validation for file type textboxes.
'- Begin utilization of the root-folder-renaming textbox
'- A confirmation window to delete after the
'	Clean Up button Is clicked. Window should
'	also list the names of all RAW files that
'	are to be deleted.
'- Create drop-down boxes for file type selection
'- Make sure folder renaming does not have a '.' at the
'   beginning.
' -----------------------------------------------------------



' --------------------------------------------------------------------------------
' Options
' --------------------------------------------------------------------------------
Option Explicit On
Option Strict On


' --------------------------------------------------------------------------------
' Imports
' --------------------------------------------------------------------------------
Imports System
Imports System.IO


Public Class Form1

    ' class-level variables
    Dim strRawExtension As String
    Dim strJpegExtension As String
    Dim strVideoExtension As String



    ' *****************************************************
    ' BUTTON-CLICK CODE
    ' *****************************************************


    '----------------------------------------------------------------------------
    ' Name: btnBrowse_Click
    ' Abstract: Handles actions taken when Browse is clicked
    ' ----------------------------------------------------------------------------
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click

        Dim frmFolderSelect As New FolderBrowserDialog()

        If DialogResult.OK = frmFolderSelect.ShowDialog Then
            txtPhotoFolder.Text = frmFolderSelect.SelectedPath
        End If

    End Sub

    '----------------------------------------------------------------------------
    ' Name: btnCleanUp_Click
    ' Abstract: Handles actions taken when Clean Up is clicked
    ' ----------------------------------------------------------------------------
    Private Sub btnCleanUp_Click(sender As Object, e As EventArgs) Handles btnCleanUp.Click

        Dim strTopDirectory As String
        strTopDirectory = txtPhotoFolder.Text

        ' run clean up code only if the folder given has been properly validated
        If FolderValidation() = True Then

            ' check and get the textbox file type entries
            If GetExtensions(strRawExtension, strJpegExtension, strVideoExtension) = True Then

                ' run procedure that checks if all files in given path are 
                ' only of the three given file types
                If CheckFileExtensions(strRawExtension, strJpegExtension, strVideoExtension,
                                       strTopDirectory) = True Then

                    DeleteUnpairedRawFiles(strTopDirectory, strTopDirectory)

                Else

                    ' error message
                    MessageBox.Show("All files under the given directory must only be of the three 
                                 given file types.")

                End If

            End If

        End If

    End Sub

    ' ----------------------------------------------------------------------------
    ' Name: btnExit_Click
    ' Abstract: Handles actions taken when Exit is clicked
    ' ----------------------------------------------------------------------------
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        'close application
        Close()

    End Sub

    ' ----------------------------------------------------------------------------
    ' Name: btnOrganize_Click
    ' Abstract: Handles actions taken when Organize is clicked
    ' ----------------------------------------------------------------------------
    Private Sub btnOrganize_Click(sender As Object, e As EventArgs) Handles btnOrganize.Click

        Dim strDirectory As String = txtPhotoFolder.Text.ToString

        ' only run organize code if given folder passes validation
        If FolderValidation() = True Then

            ' check and get the textbox file type entries
            If GetExtensions(strRawExtension, strJpegExtension, strVideoExtension) = True Then

                ' run procedure that checks if all files in given path are 
                ' only of the three given file types
                If CheckFileExtensions(strRawExtension, strJpegExtension, strVideoExtension,
                                       strDirectory) = True Then

                    ' now we are OK to organize all files into their respective type folders
                    OrganizeFiles(strDirectory, strDirectory)

                    ' Delete all empty folders
                    DeleteAllEmptyFolders(strDirectory)

                Else

                    ' error message
                    MessageBox.Show("All files under the given directory must only be of the three 
                                 given file types.")

                End If

            End If

        End If

    End Sub










    ' *****************************************************
    ' PROCEDURES AND FUNCTIONS
    ' *****************************************************



    ' ----------------------------------------------------------------------------
    ' Name: FolderValidation
    ' Abstract: Returns True if the given textbox for strFolder is a valid folder
    ' ----------------------------------------------------------------------------
    Public Function FolderValidation() As Boolean

        Dim blnFolderIsGood As Boolean
        blnFolderIsGood = False
        Dim strFolder As String
        strFolder = txtPhotoFolder.Text

        ' Determines if the name is Nothing.
        If strFolder Is Nothing Or strFolder = "" Then
            blnFolderIsGood = False

        Else

            ' Determines if there are bad characters in the name.
            For Each badChar As Char In System.IO.Path.GetInvalidPathChars
                If InStr(strFolder, badChar) > 0 Then
                    blnFolderIsGood = False
                    Exit For
                End If

                ' Keep listing as True. Will change to False if If statement above is hit.
                blnFolderIsGood = True

            Next

            ' Further check to see if the string is a folder or file
            If blnFolderIsGood = True Then

                If File.Exists(strFolder) Then
                    Try
                        blnFolderIsGood = False
                        MessageBox.Show("A file was given. A folder must be given instead.")
                        txtPhotoFolder.Focus()
                        txtPhotoFolder.BackColor = Color.Yellow
                    Catch ex As Exception
                        'Log error using ex.Message.'
                    End Try
                ElseIf Directory.Exists(strFolder) Then
                    Try
                        blnFolderIsGood = True
                    Catch ex As Exception
                        'Log error using ex.Message.'
                    End Try

                Else
                    blnFolderIsGood = False
                End If

            End If

        End If

        If blnFolderIsGood = False Then

            MessageBox.Show("The folder given is not valid.")
            txtPhotoFolder.Focus()
            txtPhotoFolder.BackColor = Color.Yellow

        End If

        Return blnFolderIsGood

    End Function


    ' ----------------------------------------------------------------------------
    ' Name: GetExtensions
    ' Abstract: Returns, by reference, the file types entered by the user
    ' ----------------------------------------------------------------------------
    Public Function GetExtensions(ByRef strRawExtension As String,
                                  ByRef strJpegExtension As String,
                                  ByRef strVideoExtension As String) As Boolean

        ' define variables
        Dim blnExtensionsRecieved As Boolean

        ' check Raw textbox for input
        If txtRawFormat.Text = "" Then
            MessageBox.Show("Please enter a RAW extension type")
            txtRawFormat.BackColor = Color.Yellow
            txtRawFormat.Focus()
            Return False

        Else
            ' get from textbox
            strRawExtension = txtRawFormat.Text
        End If

        ' check jpeg textbox for input
        If txtJpegExtension.Text = "" Then
            MessageBox.Show("Please enter a jpeg extension type")
            txtJpegExtension.BackColor = Color.Yellow
            txtJpegExtension.Focus()
            Return False

        Else
            ' get from textbox
            strJpegExtension = txtJpegExtension.Text
        End If

        ' check video textbox for input
        If txtVideoFormat.Text = "" Then
            MessageBox.Show("Please enter a video extension type")
            txtVideoFormat.BackColor = Color.Yellow
            txtVideoFormat.Focus()
            Return False

        Else
            ' get from textbox
            strVideoExtension = txtVideoFormat.Text
        End If

        Return True

    End Function

    ' ----------------------------------------------------------------------------
    ' Name: CheckFileExtensions
    ' Abstract: Checks if all files in given directory are only of the three
    '           given file types
    ' ----------------------------------------------------------------------------
    Public Function CheckFileExtensions(ByVal strRawExtension As String,
                                        ByVal strJpegExtension As String,
                                        ByVal strVideoExtension As String,
                                        ByVal strDirectory As String) As Boolean

        ' Make a reference to a directory.
        Dim diDirectoryReference As New DirectoryInfo(strDirectory)

        ' Get reference points for files and directories in that directory. 
        Dim fileArray As FileInfo() = diDirectoryReference.GetFiles()
        Dim directoryArray As DirectoryInfo() = diDirectoryReference.GetDirectories()

        ' define variables
        Dim blnFilesPass As Boolean = True
        Dim file As FileInfo

        ' Comb through each file
        For Each file In fileArray

            ' check if files are any of the three given types
            If Path.GetExtension(file.FullName) <> strRawExtension And
                Path.GetExtension(file.FullName) <> strJpegExtension And
                Path.GetExtension(file.FullName) <> strVideoExtension Then

                blnFilesPass = False

                Exit For

            End If

        Next file

        ' If all files in current directory pass, then analyze subdirector(ies)
        If blnFilesPass = True Then

            ' recursively call this function on subdirectories
            For Each directory In directoryArray

                ' check subdirectory for any unmatched file types
                If CheckFileExtensions(strRawExtension, strJpegExtension,
                                       strVideoExtension, directory.FullName) = False Then

                    blnFilesPass = False

                    Exit For

                End If

            Next directory

        End If

        Return blnFilesPass

    End Function

    ' ----------------------------------------------------------------------------
    ' Name: OrganizeFiles
    ' Abstract: Groups all files into folders respective of their file types
    ' ----------------------------------------------------------------------------
    Public Sub OrganizeFiles(ByVal strTopDirectory As String, ByVal strDirectory As String)

        ' variables
        Dim strFileTypeExtension As String
        Dim file As FileInfo
        Dim blnFileMoved As Boolean
        Dim strTargetFullFileName As String
        Dim strTargetDirectory As String

        ' Make a reference to a directory.
        Dim diDirectoryReference As New DirectoryInfo(strDirectory)

        ' Get reference each file and directory in the directory
        Dim fileArray As FileInfo() = diDirectoryReference.GetFiles()
        Dim directoryArray As DirectoryInfo() = diDirectoryReference.GetDirectories()

        ' Comb through each file
        For Each file In fileArray

            ' reset the file-moved flag
            blnFileMoved = False

            ' read file type of currently iterated file
            strFileTypeExtension = Path.GetExtension(file.FullName)

            ' create the target directory and file name from this currently iterated
            ' file's file type
            strTargetDirectory = strTopDirectory + "\" + strFileTypeExtension
            strTargetFullFileName = strTopDirectory + "\" + strFileTypeExtension +
                                    "\" + file.Name

            ' if folder in top directory, with this extension doesn't exist,
            ' then create it
            For Each directory In directoryArray

                ' if current iterated directory matches the file type in question
                If directory.Name = strFileTypeExtension And
                    directory.FullName = strTargetDirectory Then

                    ' move the file to the existing directory
                    file.MoveTo(strTargetFullFileName)

                    ' indicate that the file has been moved
                    blnFileMoved = True

                    Exit For

                End If

            Next directory

            ' If the file was not moved because the proper folder didn't exist,
            ' create the proper folder, and add the file to it.
            If blnFileMoved = False Then

                ' create folder in the top folder directory
                My.Computer.FileSystem.CreateDirectory(strTargetDirectory)

                ' move the file to the directory
                file.MoveTo(strTargetFullFileName)

            End If

        Next file

        ' Perform all that was just done in this subroutine, but with all subfolders
        ' of the folder just analyzed. This is done by recursively calling this subroutine.
        ' 'directory' changes each time it is called, but strTopDirectory stays the same
        ' as many times as this is recursively called
        For Each directory In directoryArray

            If strTopDirectory <> Nothing Then

                OrganizeFiles(strTopDirectory, directory.FullName)

            End If

        Next directory

    End Sub

    ' ----------------------------------------------------------------------------
    ' Name: DeleteAllEmptyFolders
    ' Abstract: Deletes all folders and subfolders that are empty
    ' ----------------------------------------------------------------------------
    Public Sub DeleteAllEmptyFolders(ByVal strTopDirectory As String)

        ' Make a reference to a directory.
        Dim diDirectoryReference As New DirectoryInfo(strTopDirectory)

        ' Get reference each file and directory in the directory
        Dim directoryArray As DirectoryInfo() = diDirectoryReference.GetDirectories()

        ' delete empty folders
        For Each directory In directoryArray

            ' if nothing exists in the current directory, then delete it
            If directory.GetFiles.Length = 0 And
                directory.GetDirectories.Length = 0 Then

                My.Computer.FileSystem.DeleteDirectory(directory.FullName,
                Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.ThrowIfDirectoryNonEmpty)

            Else
                ' If files and/or folders were found, run this same sub on folders found,
                ' therefore digging deeper.
                DeleteAllEmptyFolders(directory.FullName)

                ' After finishing digging from currently iterated directory,
                ' if everything is now clear, delete the currently iterated directory.
                If directory.GetFiles.Length = 0 And
                directory.GetDirectories.Length = 0 Then

                    My.Computer.FileSystem.DeleteDirectory(directory.FullName,
                    Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.ThrowIfDirectoryNonEmpty)

                End If

            End If

        Next directory

    End Sub

    ' ----------------------------------------------------------------------------
    ' Name: DeleteUnpairedRawFiles
    ' Abstract: Deletes raw image files that have no jpeg with a matching name
    ' ----------------------------------------------------------------------------
    Public Sub DeleteUnpairedRawFiles(ByVal strTopDirectory As String, ByVal strDirectory As String)

        ' variables
        Dim strFileTypeExtension As String
        Dim file As FileInfo

        ' Make a reference to a directory.
        Dim diDirectoryReference As New DirectoryInfo(strDirectory)

        ' Get reference each file and directory in the directory
        Dim fileArray As FileInfo() = diDirectoryReference.GetFiles()
        Dim directoryArray As DirectoryInfo() = diDirectoryReference.GetDirectories()


        ' first, identify each file that exists, and analyze it using FindMatchingJpeg.
        ' Comb through each file
        For Each file In fileArray

            ' read file type of currently iterated file
            strFileTypeExtension = Path.GetExtension(file.FullName)

            ' if the currently iterated file is a raw file, then proceed to find
            ' if it has a jpeg match.
            If strFileTypeExtension = strRawExtension Then

                ' start the process to get the shared file name with no extension
                ' define variables
                Dim strFileNameNoExtension As String
                Dim intExtensionSize As Integer
                Dim intFileNameSize As Integer
                Dim intFileNameNoExtensionSize As Integer

                ' get lengths
                intExtensionSize = strFileTypeExtension.Length
                intFileNameSize = file.Name.Length
                intFileNameNoExtensionSize = intFileNameSize - intExtensionSize

                strFileNameNoExtension = file.Name.Remove(intFileNameNoExtensionSize, intExtensionSize)

                ' If a jpeg match to the raw file was not found, delete the raw file
                If FindMatchingJpeg(strTopDirectory, strTopDirectory, strFileNameNoExtension) = False Then

                    My.Computer.FileSystem.DeleteFile(file.FullName)

                End If

            End If

        Next file

        ' Perform all that was just done in this subroutine, but with all subfolders
        ' of the folder just analyzed. This is done by recursively calling this subroutine.
        ' 'directory' changes each time it is called, but strTopDirectory stays the same
        ' as many times as this is recursively called
        For Each directory In directoryArray

            If strTopDirectory <> Nothing Then

                DeleteUnpairedRawFiles(strTopDirectory, directory.FullName)

            End If

        Next directory


    End Sub

    ' ----------------------------------------------------------------------------
    ' Name: FindMatchingJpeg
    ' Abstract: Takes strSharedFileName as the file name that is supposed to be
    '           shared with a matching Jpeg. Do not include extension. Returns
    '           False if no match is found.
    ' ----------------------------------------------------------------------------
    Public Function FindMatchingJpeg(ByVal strTopDirectory As String, ByVal strDirectory As String,
                                     ByVal strSharedFileName As String) As Boolean

        ' variables
        Dim strFileTypeExtension As String
        Dim file As FileInfo
        Dim blnMatchFound As Boolean

        blnMatchFound = False

        ' Make a reference to a directory.
        Dim diDirectoryReference As New DirectoryInfo(strDirectory)

        ' Get reference each file and directory in the directory
        Dim fileArray As FileInfo() = diDirectoryReference.GetFiles()
        Dim directoryArray As DirectoryInfo() = diDirectoryReference.GetDirectories()


        ' first, identify each file that exists, and analyze it using FindMatchingJpeg.
        ' Comb through each file
        For Each file In fileArray

            ' reset the file-moved flag
            blnMatchFound = False

            ' read file type of currently iterated file
            strFileTypeExtension = Path.GetExtension(file.FullName)

            ' If the currently iterated file is a jpeg file, then proceed to see
            ' if it's name matches the raw file in question.
            If strFileTypeExtension = strJpegExtension Then

                ' start the process to get the jpeg file name without the jpeg extension
                Dim strJpegNameNoExtension As String
                Dim intExtensionSize As Integer
                Dim intJpegNameSize As Integer
                Dim intJpegNameNoExtensionSize As Integer

                ' get lengths
                intExtensionSize = strFileTypeExtension.Length
                intJpegNameSize = file.Name.Length
                intJpegNameNoExtensionSize = intJpegNameSize - intExtensionSize

                strJpegNameNoExtension = file.Name.Remove(intJpegNameNoExtensionSize, intExtensionSize)

                ' If a jpeg match to the raw file was not found, return false
                If strJpegNameNoExtension = strSharedFileName Then

                    ' If statement came back True, so a match was found. We flip the flag
                    ' to true and exit the For loop because our search for a match has concluded.
                    blnMatchFound = True

                    Exit For

                Else

                    ' flag stays False, because a match was not found with currently iterated file
                    blnMatchFound = False

                End If

            End If

        Next file

        ' Perform all that was just done in this subroutine, but with all subfolders
        ' of the folder just analyzed. This is done by recursively calling this subroutine.
        ' 'directory' changes each time it is called, but strTopDirectory stays the same
        ' as many times as this is recursively called. Only perform this if a match still
        ' has not been found.
        If blnMatchFound = False Then

            For Each directory In directoryArray

                If strTopDirectory <> Nothing Then

                    ' recursively call this function on a subsequent directory
                    blnMatchFound = FindMatchingJpeg(strTopDirectory, directory.FullName, strSharedFileName)

                    ' if match found, then exit the Directory Search
                    If blnMatchFound = True Then Exit For

                End If

            Next directory

        End If

        Return blnMatchFound

    End Function

End Class