@echo off

dotnet restore LoadingIndicators.Avalonia/LoadingIndicators.Avalonia.csproj
dotnet build LoadingIndicators.Avalonia/LoadingIndicators.Avalonia.csproj -c Release --no-restore
dotnet pack LoadingIndicators.Avalonia/LoadingIndicators.Avalonia.csproj -c Release --no-build -o ./artifacts
