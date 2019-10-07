function Remove($path) {
    if (Test-Path $path) {
        Remove-Item $path -Recurse -Force
    } else {
        Write-Host "Path don't exist: $path"
    }
}

Remove(".vs")

Remove("OpenWithPPGUI\obj")
Remove("OpenWithPPGUI\.vs")
Remove("OpenWithPPGUI\*.csproj.user")
Remove("OpenWithPPGUI\bin\*.ilk")
Remove("OpenWithPPGUI\bin\*.lib")
Remove("OpenWithPPGUI\bin\*.exp")

Remove("OpenWithPPShellExtension\.vs")
Remove("OpenWithPPShellExtension\Debug")