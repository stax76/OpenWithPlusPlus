
$ScriptDir = Split-Path -Path $PSCommandPath -Parent
$ExePath = $ScriptDir + '\OpenWithPPGUI\bin\OpenWithPPGUI.exe'
$Version = [Diagnostics.FileVersionInfo]::GetVersionInfo($ExePath).FileVersion
$DesktopDir = [Environment]::GetFolderPath('Desktop')
$TargetDir = $DesktopDir + '\OpenWithPP-' + $Version
Copy-Item $ScriptDir\OpenWithPPGUI\bin $TargetDir -Recurse -Exclude *.lib, *.exp, *.ilk
& 'C:\Program Files\7-Zip\7z.exe' a -t7z -mx9 "$TargetDir.7z" -r "$TargetDir\*"
