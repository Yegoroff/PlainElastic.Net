@set NUGET="packages\NuGet.CommandLine.1.6.0\tools\NuGet.exe"

@echo ==========================
@echo NuGet package publishing.
@%NUGET% Push NuGet\PlainElastic.Net.1.0.43.nupkg
@if not errorlevel 0 goto errors

@echo PlainElastic.Net publishing sucessfull.
@goto end

:error
@echo Error occured during PlainElastic.Net publishing.
@pause

:end
@pause