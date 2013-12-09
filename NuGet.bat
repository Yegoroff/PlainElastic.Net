@set DEVENV100="%programfiles(x86)%\Microsoft Visual Studio 11.0\Common7\IDE\devenv.exe"
@if "%programfiles(x86)%"=="" (@set DEVENV100="%programfiles%\Microsoft Visual Studio 11.0\Common7\IDE\devenv.exe")

@set NUGET="packages\NuGet.CommandLine.1.6.0\tools\NuGet.exe"

@echo ==========================
@echo Building PlainElastic.Net.
@rmdir src\PlainElastic.Net\bin /s /q
%DEVENV100% /nologo /build Release "PlainElastic.Net.sln"
@if errorlevel 1 goto error

@echo ==========================
@echo Copying PlainElastic.Net assemblies.
@rmdir NuGet\lib /s /q
@mkdir NuGet\lib
xcopy src\PlainElastic.Net\bin\Release NuGet\lib /s /y
@if errorlevel 0 goto nuget
@goto error

:nuget
@echo ==========================
@echo NuGet package creation.
@%NUGET% pack NuGet\plainelastic.net.nuspec -basePath NuGet -o NuGet
@if not errorlevel 0 goto error

@echo PlainElastic.Net build sucessfull.
@goto end

:error
@echo Error occured during PlainElastic.Net build.
@pause

:end
@pause