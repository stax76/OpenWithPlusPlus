function Remove($path) {
    if (Test-Path $path) {
        Remove-Item $path -Recurse -Force
        Write-Host "Deleted: $path" -ForegroundColor Green
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