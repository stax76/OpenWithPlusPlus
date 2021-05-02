
$ExePath    = $PSScriptRoot + '\OpenWithPPGUI\bin\OpenWithPPGUI.exe'
$Version    = [Diagnostics.FileVersionInfo]::GetVersionInfo($ExePath).FileVersion
$workDir    = 'D:\Work'
$TargetDir  = $workDir + '\OpenWithPP-' + $Version

Copy-Item $PSScriptRoot\OpenWithPPGUI\bin $TargetDir -Recurse

Remove-Item $TargetDir\OpenWithPPShellExtension.pdb -ErrorAction Ignore
Remove-Item $TargetDir\OpenWithPPShellExtension.lib -ErrorAction Ignore
Remove-Item $TargetDir\OpenWithPPShellExtension.exp -ErrorAction Ignore
Remove-Item $TargetDir\OpenWithPPShellExtension.ilk -ErrorAction Ignore

& 'C:\Program Files\7-Zip\7z.exe' a -t7z -mx9 "$TargetDir.7z" -r "$TargetDir\*"
Start-Process $workDir
