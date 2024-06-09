cd src/AvaloniaApplication3/AvaloniaApplication3
dotnet build
cd ../../..
cd src/AvaloniaApplication3/AvaloniaApplication3/bin/Debug/net8.0/
echo dotnet run --project ../../../AvaloniaApplication3.csproj >> run.sh
dotnet run --project ../../../AvaloniaApplication3.csproj