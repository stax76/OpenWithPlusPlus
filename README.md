# Open with++

Open with++ is a shell extension which adds a customizable context menu to the windows file explorer.

It allows to execute a command line on the selected files and folders.

Feature requests and usage questions are welcome.

Warning: Certain shell extensions including Open with++ break certain items in the [Win+X menu](https://www.digitalcitizen.life/simple-questions-what-winx-menu-how-access-it) in Windows 10.

![](https://raw.githubusercontent.com/stax76/OpenWithPlusPlus/master/Main.png)

## Help

Open with++ allows to add customized context menu items in the Windows File Explorer either on top level or in a sub menu.

Open with++ is a context menu shell extension that allows you to quickly open the selected files or folders with the customized commands. It adds a menu on top level or as submenu with customized menu items to the shell context menu when right clicking files or folders in Windows File Explorer. Open with++ also provides some predefined commands, such as CMD and PowerShell.

Holding down Control or Shift key while selecting the command from the Open with++, Open with++ will execute the selected command with administrative privileges.

To customize the commands in Open with++ menu, right click a file or folder in Windows File Explorer, then choose "Open with++ > Customize Open with++" from Open with++ submenu.

The location where Open with++ saves it's settings is:

C:\Users\user\AppData\Roaming\Open with++\Settings.xml

There are a few defaults commands included, for suggestions about defaults please use the issue tracker at:

https://github.com/stax76/OpenWithPlusPlus/issues

### Add

Adds a new command to Open with++ menu.

### Remove

Removes the selected command from Open with++ menu.

### Clone

Dublicates a command.

### Tools > Replace in paths of all items

Allows to search and replaces in all files in one go.

### Tools > Options

Allows to define macros to be used as File Types.

### Install/Uninstall

Installs/Uninstalls the shell extension. Uninstall requires a reboot, logout or restarting the relevant processes manually, Windows File Explorer can be restarted with the task manager.

### Name

Specifies the name of the command.

### File Types

Specifies for which file types the menu is shown, all files are defined with *.* .

### Path

Specifies the program to be used for opening the selected files or folders.

### Arguments

Specifies the arguments that are passed to the program when the command is executed, such as command line switches. You can also use environment variables and the predefined variable %paths% which expands to the paths of the selected files or folders. Each path is enclosed in double quotation marks and separated by a space.

### Show in sub menu

Specifies if the menu is created on top level or as sub menu

### Show for directories

Specifies that the menu/command is shown when folders are selected or the folder background is clicked.

### Run as admin

Specifies that the command executes with elevated privilegs. When disable commands can still be executed with elevated privilegs by holding down Control or Shift key while selecting the command from the Open with++ menu.

### Run hidden

Runs the process with hidden window.

## Frequently Ask Questions

Does Open with++ set the working directory?

Yes, it's set to the directory of the selected files or folders.