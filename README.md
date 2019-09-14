# Open with++

Open with++ is a shell extension which adds a customizable context menu to the windows file explorer.

Warning: Certain shell extensions including Open with++ break certain items in the Win+X menu in Windows 10

![](https://raw.githubusercontent.com/stax76/OpenWithPlusPlus/master/OpenWithPlusPlus.png)

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

Installs/Uninstalls the shell extension. It is however only unloaded from the explorer process after a reboot or after the explorer is restarted which can easily be achieved with the task manager. Once the libaray is unloaded it can be moved or deleted.

### Name

Specifies the name of the command.

### File Types

Specifies for which file types the menu is shown.

### Path

Specifies the program to be used for opening the selected files or folders. If the program file resides on the system path, you can enter just the file name. If not, enter the full path of the program. You can also use environment variables to specify program which will be replaced with corresponding variable value when executing the command (for example, "%windir%\explorer.exe").

### Arguments

Specifies the arguments that are passed to the program when the command is executed, such as command line switches. You can also use environment variables and the predefined variable %paths% which expands to the paths of the selected files or folders. Each path is enclosed in double quotation marks and separated by a space.

### Show in sub menu

Specifies if the menu is created on top level or as sub menu

### Show for directories

Specifies that the menu/command is shown when folders are selected or the folder background is clicked.

### Show for all file types

Specifies that the menu/command is shown for any type of selected files, this is usefull for a text editor for instance because files that contain text can have countless file extensions.

### Run as admin

Specifies that the command executes with elevated privilegs. When disable commands can still be executed with elevated privilegs by holding down Control or Shift key while selecting the command from the Open with++ menu.