
# Open with++

Open with++ is a shell extension that allows to add command line driven custom menu items to the Windows File Explorer context menu.


## Screenshots

![](https://raw.githubusercontent.com/stax76/OpenWithPlusPlus/master/img/Main.png)

![](https://raw.githubusercontent.com/stax76/OpenWithPlusPlus/master/img/Menu.png)


## Setup

The requirements are Windows 7 x64 or higher, [.NET Framework 4.8 x64](https://dotnet.microsoft.com/download/dotnet-framework/net48) and [Visual C++ 2019 Redistributable x64](https://support.microsoft.com/en-gb/help/2977003/the-latest-supported-visual-c-downloads).

Start the application and click on the Install button in the toolbar.


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

Installs/Uninstalls the shell extension. Uninstall requires a reboot, logout or restarting the relevant processes manually, Windows File Explorer can be restarted with the task manager. Common processes which load context menu shell extensions are Windows File Explorer and [Everything](https://www.voidtools.com/).


### Name

Specifies the name of the command.


### File Types

Specifies for which file types the menu is shown.

All files: `*.*`  
txt and md: `txt md`  

The options dialog defines macros for common file types:

```
%video% = mpg avi vob mp4 d2v divx mkv avs 264 mov wmv part flv ifo h264 asf webm mpeg mpv y4m avc hevc 265 h265 m2v m2ts vpy mts webm ts m4v part vpy rar crdownload
%audio% = mp2 mp3 ac3 wav w64 m4a dts dtsma dtshr dtshd eac3 thd thd+ac3 ogg mka aac opus flac mpa
%subtitle% = sub sup idx ass aas srt
%image% = png jpg jpeg gif bmp ico
```
W
Media files: `%audio% %video% %image%`  

Macros are only supported in the File Types property.


### Path

Specifies the program to be used for opening the selected files or folders.

Environment variables get expanded.

### Arguments

Specifies the arguments that are passed to the program when the command is executed. You can use the predefined variable %paths% which expands to the paths of the selected files or folders. Do not enclose the %paths% macro in quotes as Open with++ adds them automatically when the macro is expanded, each path is enclosed in double quotation marks and separated by a space.

Environment variables get expanded.

### Working Directory

The working directory the process will use, if not specified the working directory will be set to the directory of the selected files or folders.

Environment variables get expanded.

### Icon

Supported file types are ICO, EXE and DLL. EXE and DLL files can contain different icons, Open with++ will show a dialog that allows to choose which icon in the EXE or DLL file to use.

Environment variables get expanded.

[IrfanView](https://www.irfanview.com/) can be used to create icons.

[Here is an article](https://www.digitalcitizen.life/where-find-most-windows-10s-native-icons) that shows which Windows DLLs contain icon resources.


### Show in sub menu

Specifies if the menu is created on top level or as sub menu.


### Show for directories

Specifies that the menu command is shown when folders or the folder background is selected.


### Show only if Ctrl key is pressed

The menu item is only visible if the Control key is pressed.


### Run as admin

Specifies that the command executes with elevated privilegs. When disabled commands can still be executed with elevated privilegs by holding down Shift key while selecting the menu command.


### Run hidden

Runs the process with hidden window. Useful to hide terminal tools like PowerShell.


## Tips & Tricks

Holding down the Shift key while selecting a command from the Open with++ menu will execute the command with elevated privileges.

Path, Arguments, Working Directory and Icon support the usage of environment variables.

The location of Open with++ is available as environment variable %OpenWithPPDir%.

## Configuration Suggestions


### Visual Studio Code

Open files or a directory with Visual Studio Code.

**Name**: `Visual Studio Code`  
**File Types**: `*.*`  
**Path**: `C:\Program Files\Microsoft VS Code\Code.exe`  
**Arguments**: `%paths%`  
**Show for directories**: `checked`  
**Icon**: `C:\Program Files\Microsoft VS Code\Code.exe,0`  


### MediaInfo.NET

Show media info using [MediaInfo.NET](https://github.com/stax76/MediaInfo.NET).

**Name**: `MediaInfo.NET`  
**File Types**: `%audio% %video% %subtitle% %image%`  
**Path**: `D:\your path here\MediaInfoNET.exe`  
**Arguments**: `%paths%`  
**Icon**: `D:\your path here\MediaInfoNET.exe,0`  


### PowerShell

Start PowerShell at the given folder.

**Name**: `PowerShell`  
**Path**: `powershell.exe`  
**Arguments**: `-nologo`  
**Icon**: `C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe,0`  


### Command Prompt

Start CMD at the given folder.

**Name**: `Command Prompt`  
**Path**: `cmd.exe`  
**Show in submenu**: `checked`  
**Icon**: `cmd.exe,0`  


### Windows Terminal

Start Windows Terminal at the given folder.

In the Windows Terminal profile settings define:

```
"startingDirectory" : null,
```

**Name**: `Windows Terminal`  
**Path**: `wt.exe`  
**Show for directories**: `checked`  
**Icon**: `%OpenWithPPDir%\Icons\Windows Terminal.ico`  

Open with++ includes a Windows Terminal ICO file, this icon can be used to create a shortcute in order to pin it to the start menu, in the shortcut settings the working directory can be set, something the original UWP start menu entry does not allow.


### Execute PowerShell script using Windows Terminal

**Name**: `Execute`  
**File Types**: `ps1`  
**Path**: `wt.exe`  
**Arguments**: `-- powershell.exe -NoLogo -NoExit -ExecutionPolicy Unrestricted -File %paths%`  
**Icon**: `D:\Apps\OpenWithPlusPlus\Icons\Windows Terminal.ico`  


### Copy Paths

Copy the paths of selected files and folders to the clipboard, it can be achieved with a PowerShell one-liner:

```PowerShell
Set-Clipboard ($args -join "`r`n")
```

**Name**: `Copy Paths`  
**File Types**: `*.*`  
**Path**: `powershell.exe`  
**Arguments**: `-file "D:\copy paths.ps1" %paths%`  
**Show for directories**: `checked`  
**Run hidden**: `checked`  


### Play with mpv.net

Play media files with the mpv.net media player.

**Name**: `mpv.net`  
**File Types**: `%audio% %video% %image%`  
**Path**: `C:\Program Files\mpv.net\mpvnet.exe`  
**Arguments**: `%paths%`  
**Icon**: `C:\Program Files\mpv.net\mpvnet.exe,0`  


### Add to mpv.net playlist

Add media files to the mpv.net media player playlist.

**Name**: `Add to mpv.net playlist`  
**File Types**: `%audio% %video% %image%`  
**Path**: `C:\Program Files\mpv.net\mpvnet.exe`  
**Arguments**: `--queue %paths%`  
**Icon**: `C:\Program Files\mpv.net\mpvnet.exe,0`  


### Chrome

Open files in Google Chrome.

**Name**: `Chrome`  
**File Types**: `pdf htm html`  
**Path**: `C:\Program Files (x86)\Google\Chrome\Application\chrome.exe`  
**Arguments**: `%paths%`  
**Icon**: `C:\Program Files (x86)\Google\Chrome\Application\chrome.exe,0`  
