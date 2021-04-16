param([string]$targetName, [string]$outputDir)

$pluginPath = "$Env:APPDATA\Elgato\StreamDeck\Plugins\$targetName.sdPlugin"

taskkill /f /t /im "StreamDeck.exe"

taskkill /f /t /im "$targetName.exe" /fi "STATUS eq RUNNING | NOT RESPONDING"

Remove-Item -Path "$pluginPath" -Force -Recurse

Copy-Item -Path "$outputDir" -Destination "$pluginPath" -Force -Recurse -Container: $false -Exclude "*.pdb"

Start-Process -FilePath "C:\Program Files\Elgato\StreamDeck\StreamDeck.exe"