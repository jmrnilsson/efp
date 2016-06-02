#!/bin/sh -x
ls . | grep -v Program.cs | grep .cs | xargs rm;
rm chinookContext.cs;
dotnet restore;
dotnet build;
dotnet ef dbcontext scaffold Filename=/Users/martinnilsson/devwork/efpad/Scaffold09/chinook.db Microsoft.EntityFrameworkCore.Sqlite;
