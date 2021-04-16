param([string]$targetName, [string]$outputDir, [string]$runtimeIdentifier)

$pluginName = "$targetName.sdPlugin"

if($runtimeIdentifier -EQ "osx-x64") {
    $pluginName = $pluginName -Replace $targetName, "$targetName.mac"

    Remove-Item "$PSScriptRoot\$targetName.mac.streamDeckPlugin" -ErrorAction Ignore
} else {
    Remove-Item "$PSScriptRoot\$targetName.streamDeckPlugin" -ErrorAction Ignore
}

Rename-Item "$($outputDir)publish" $pluginName

. "$PSScriptRoot\tools\DistributionTool.exe" -b -i "$($outputDir)$pluginName" -o "$PSScriptRoot"

Remove-Item "$($outputDir)$pluginName" -Force -Recurse