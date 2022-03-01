****************************************************************
Program Name:  Raw File Deleter
Author:        John Neumeier
Date started:  01/30/22
Updated:       02/28/22
Abstract:      Windows Forms Application that helps the user
               delete all RAW image files in a folder that do
               not have an accompanying JPG file of same name.
	       The user is also able to organize all files,
	       (of the filetypes indicated) into folders of
	       their own file type name.

Detailed Description:
	  This is an application I wrote for myself in helping
	  organize incoming photos from my digital camera.
	  I have my camera set to store a RAW image file and
	  a compressed JPG file for each photo I take. I do this 
	  so I can preview my photos faster once I've 
	  imported them from the camera, as cycling through RAW
	  files takes much longer than JPG files. When I delete
	  a JPG photo that I don't want to keep, the computer
	  does not automatically delete the accompanying RAW
	  file. This is what this program is for. After I
	  go through and delete the JPGs I don't want, I
	  use this program to look through the photo folder
	  to find RAW files that do not have an accompanying
	  JPG of the same name. After locating those RAW files
	  automatically, this program then deletes those RAW files.
	  This saves me a lot of time when I've imported several
	  hundred photos, and don't want to go back and personally
	  identify the RAW files that have no accompanying JPG.

	  This program also has functionality to organize all files
	  within (only if files are of the three specified types)
	  into folders depending on each file's type.
****************************************************************



-----------------------------------------------------------
Still to implement

- Proper validation for file type textboxes.
- Begin utilization of the root-folder-renaming textbox
- A confirmation window to delete after the
	Clean Up button Is clicked. Window should
	also list the names of all RAW files that
	are to be deleted.
- Make sure folder renaming does not have '.' at the
   beginning.
-----------------------------------------------------------