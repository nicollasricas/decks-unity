param ([string]$targetDir, [string]$targetVersion, [string]$runtimeIdentifier)

$manifestPath = "$($targetDir)manifest.json"

Write-Host "[$runtimeIdentifier] Updating plugin manifest at $manifestPath"

$manifest = Get-Content $manifestPath -Raw | ConvertFrom-Json

Write-Host "Current Version: $($manifest.Version)"

$manifest.Version = $targetVersion.Split(".", 4)[0,1,2] -Join "."

Write-Host "New Version: $($manifest.Version)"

if($runtimeIdentifier -EQ "osx-x64") {
    $manifest.OS[0].Platform = "mac"
    $manifest.OS[0].MinimumVersion = "10.11"

    Write-Host "New Platform: $($manifest.OS[0].Platform) / Version: $($manifest.OS[0].MinimumVersion)"
}

$manifest | ConvertTo-Json -Depth 32 -Compress | Set-Content $manifestPath