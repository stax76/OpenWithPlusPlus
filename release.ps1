$scriptDir = Split-Path -Path $PSCommandPath -Parent
$exePath = $scriptDir + "\OpenWithPPGUI\bin\OpenWithPPGUI.exe"
$version = [Diagnostics.FileVersionInfo]::GetVersionInfo($exePath).FileVersion
$desktopDir = [Environment]::GetFolderPath("Desktop")
$targetDir = $desktopDir + "\OpenWithPP-" + $version
aaa
Copy-Item $scriptDir\OpenWithPPGUI\bin $targetDir -Recurse -Exclude *.lib, *.exp
Copy-Item $scriptDir\README.md $targetDir\README.md
$7zPath = "C:\Program Files\7-Zip\7z.exe"
$args = "a -t7z -mx9 $targetDir.7z -r $targetDir\*"
Start-Process -FilePath $7zPath -ArgumentList $args