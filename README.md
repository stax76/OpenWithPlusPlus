
# Open with++

Warning: Certain shell extensions including Open with++ break certain items in the [Win+X menu](https://www.digitalcitizen.life/simple-questions-what-winx-menu-how-access-it) in Windows 10.

Open with++ is a shell extension which adds a customizable context menu to the Windows File Explorer. It allows to execute a command line on the selected files and folders. A common task is to open files with an application like using the regular Open with menu.

Feature requests and usage questions are welcome.

## Screenshot

![](https://raw.githubusercontent.com/stax76/OpenWithPlusPlus/master/Main.png)

## Setup

The requirements are Windows 7 x64 or higher and .NET Framework 4.8.

Start the application and click on the Install button in the toolbar.

## Usage

To customize the commands of Open with++, right click a file or folder in Windows File Explorer, then choose "Open with++ > Customize Open with++" from Open with++ submenu. Example commands are listed under [Configuration Suggestions](#configuration-suggestions).

## GUI Elements

### Add

Adds a new command to Open with++ menu.

### Remove

Removes the selected command from Open with++ menu.

### Clone

Dublicates the selected command.

### Options

Allows to define a custom settings folder and macros that are usable in the File Type property.

### Install/Uninstall

Installs/Uninstalls the shell extension. Uninstall requires a reboot, logout or restarting the relevant processes manually, Windows File Explorer can be restarted with the task manager.

### Name

Specifies the name of the command.

### File Types

Specifies for which file types the menu is shown, all files are defined with `*.*`. The options dialog defines macros for common file types.

### Path

Specifies the program to be used for opening the selected files or folders.

### Arguments

Specifies the arguments that are passed to the program when the command is executed, such as command line switches. You can use the predefined variable %paths% which expands to the paths of the selected files or folders. Each path is enclosed in double quotation marks and separated by a space.

### Show in sub menu

Specifies if the menu is created on top level or as sub menu.

### Show for directories

Specifies that the menu command is shown when folders or the folder background is selected.

### Run as admin

Specifies that the command executes with elevated privilegs. When disabled commands can still be executed with elevated privilegs by holding down Control or Shift key while selecting the command from the Open with++ menu.

### Run hidden

Runs the process with hidden window.

## Tips & Tricks

- Holding down the Control or Shift key while selecting a command from the Open with++ menu will execute the command with elevated privileges.
- Whenever a command is executed Open with++ sets the working directory to the directory of the files and folders that are selected in Windows File Explorer.

## Configuration Suggestions

### Visual Studio Code

Visual Studio Code is not only great for code and markup but due to its fast load times also great as general text editor, in my opinion it's far superior to Notepad++ and also better than Sublime Text.

**Name**: Visual Studio Code  
**File Types**: `*.*`  
**Path**: C:\Program Files\Microsoft VS Code\Code.exe  
**Arguments**: %paths%  
**Show for directories**: checked

### MediaInfo

If you use StaxRip for video encoding then you might want to use it's MediaInfo GUI from Explorer because it supports High DPI and it's searchable.

**Name**: MediaInfo  
**File Types**: %audio% %video% %subtitle% %image%  
**Path**: D:\your path here\StaxRip.exe  
**Arguments**: -mediainfo %paths%  

### PowerShell

Open with++ will always set the working directory to the directory of Windows File Explorer.

I recommend using the new [Windows Terminal](https://github.com/microsoft/terminal).

**Name**: PowerShell  
**Path**: powershell  
**Arguments**: -nologo  
**Show for directories**: checked  

### CMD

Open with++ will always set the working directory to the directory of Windows File Explorer.

I recommend using PowerShell and the new [Windows Terminal](https://github.com/microsoft/terminal).

**Name**: CMD  
**Path**: cmd  
**Show in submenu**: checked  
**Show for directories**: checked  

### Windows Terminal

Open with++ will always set the working directory to the directory of Explorer. In the current preview of Windows Terminal set the following setting:

    "startingDirectory" : null

**Name**: Windows Terminal  
**Path**: wt  
**Show for directories**: checked  

### Execute

To execute a selected PowerShell script use:

**Name**: Execute  
**File Types**: ps1  
**Path**: powershell  
**Arguments**: -nologo -noexit -file %paths%  

### Copy Paths

A common task is copying the paths of the selected files and folders to the clipboard, this can be achieved with a simple PowerShell script:

Code:
```Set-Clipboard ($args -join "`r`n")```

**Name**: Copy Paths  
**File Types**: `*.*`  
**Path**: powershell  
**Arguments**: `-file "D:\copy paths.ps1" %paths%`  
**Show for directories**: checked  
**Run hidden**: checked  

### Your help

If you know other common commands that might be interesting for Open with++ users then please create an issue on the tracker.