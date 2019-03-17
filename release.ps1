$scriptDir = split-path -Path $PSCommandPath -parent
$exePath = $scriptDir + "\OpenWithPPGUI\bin\OpenWithPPGUI.exe"
$version = [Diagnostics.FileVersionInfo]::GetVersionInfo($exePath).FileVersion
$desktopDir = [Environment]::GetFolderPath("Desktop")
$targetDir = $desktopDir + "\OpenWithPP-" + $version
copy-item $scriptDir\OpenWithPPGUI\bin $targetDir -recurse -exclude *.lib, *.exp
copy-item $scriptDir\README.md $targetDir\README.md
$7zPath = "C:\Program Files\7-Zip\7z.exe"
$args = "a -t7z -mx9 $targetDir.7z -r $targetDir\*"
start-process -filepath $7zPath -argumentlist $args