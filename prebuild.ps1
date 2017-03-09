Write-Host "Patching Project version..."
(Get-Content .\Lorem.NET\Lorem.NET.csproj).replace('<Version>2.0.0</Version>', "<Version>$($Env:APPVEYOR_BUILD_VERSION)</Version>") | Set-Content .\Lorem.NET\Lorem.NET.csproj
(Get-Content .\Lorem.NET\Lorem.NET.csproj).replace('<AssemblyVersion>2.0.0</AssemblyVersion>', "<AssemblyVersion>$($Env:APPVEYOR_BUILD_VERSION)</AssemblyVersion>") | Set-Content .\Lorem.NET\Lorem.NET.csproj
(Get-Content .\Lorem.NET\Lorem.NET.csproj).replace('<FileVersion>2.0.0</FileVersion>', "<FileVersion>$($Env:APPVEYOR_BUILD_VERSION)</FileVersion>") | Set-Content .\Lorem.NET\Lorem.NET.csproj
Write-Host "Project to use version $($Env:APPVEYOR_BUILD_VERSION)"
