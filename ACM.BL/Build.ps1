param (
    [Parameter(Mandatory=$false,Position=1)]
    [string] $Configuration = "Release"
)

$watch = [System.Diagnostics.Stopwatch]::StartNew()
$scriptPath = Split-Path (Get-Variable MyInvocation).Value.MyCommand.Path 
Set-Location $scriptPath

try
{
	Write-Host "Restoring nuget packages..."
	& nuget.exe restore "$scriptPath\ACM.BL.sln"
	
	if ($LASTEXITCODE -ne 0) {
        Write-Host "Nuget restore has failed! " $watch.Elapsed -ForegroundColor Red
        exit $LASTEXITCODE
    }

    Write-Host "Building ACM BL ($Configuration)..." -ForegroundColor Green
    Stop-Process -processname msbuild* -Force
       
	$msbuild = "C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe"
	& $msbuild "$scriptPath\ACM.BL.sln" /p:Configuration="$Configuration" /p:Platform="Any CPU" /t:Rebuild  /p:VisualStudioVersion=14.0 /m /v:n
        
    if ($LASTEXITCODE -ne 0) {
        Write-Host "ACM BL build has failed! " $watch.Elapsed -ForegroundColor Red
        exit $LASTEXITCODE
    }
        
    Write-Host "ACM BL ($Configuration) Deploy: " $watch.Elapsed -ForegroundColor Yellow        
    exit $LASTEXITCODE
}
finally
{
    Set-Location $scriptPath
}