$scriptDir = split-path -Path $PSCommandPath -parent
$exePath = $scriptDir + "\OpenWithPPGUI\bin\OpenWithPPGUI.exe"
$version = [Diagnostics.FileVersionInfo]::GetVersionInfo($exePath).FileVersion
$desktopDir = [Environment]::GetFolderPath("Desktop")
$targetDir = $desktopDir + "\OpenWithPP-" + $version
copy-item $scriptDir\README.md $scriptDir\OpenWithPPGUI\bin\README.md
copy-item $scriptDir\OpenWithPPGUI\bin $targetDir -recurse -exclude *.lib, *.exp, *.ilk
& "C:\Program Files\7-Zip\7z.exe" a -t7z -mx9 "$targetDir.7z" -r "$targetDir\*"