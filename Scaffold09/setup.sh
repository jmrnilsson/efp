dotnet restore;
dotnet build;
dotnet ef dbcontext scaffold Filename=/Users/martinnilsson/devwork/efpad/Scaffold09/chinook.db Microsoft.EntityFrameworkCore.Sqlite;

mkdir curl
curl -OL https://chinookdatabase.codeplex.com/downloads/get/557747
unzip -o ChinookDatabase1.4_CompleteVersion.zip -d ./curl/ && rm ./ChinookDatabase1.4_CompleteVersion.zip
