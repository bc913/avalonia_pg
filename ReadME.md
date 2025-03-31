# Avalonia UI Playground

## Generate template
dotnet new avalonia.mvvm -o src/UI -n Bcan.Pg.UI -m CommunityToolkit
## Build
dotnet build Bcan.Avalonia.Pg.sln --no-restore
## Run
dotnet run --project src/UI/Bcan.Pg.UI.csproj --no-restore --no-build