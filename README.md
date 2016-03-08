# efp

## 01

    dnvm list
    dnvm use 1.0.0-rc2-16551 -r mono
    dnu restore
    dnvm use 1.0.0-rc2-16551 -r coreclr
    dnx run
    
+ https://github.com/dotnet/coreclr/blob/master/Documentation/install/get-dotnetcore-dnx-osx.md

## 02 

    dnvm install 1.0.0-rc1-final -r coreclr
    dnvm upgrade
    dnu restore
    dnu build --quiet
    dnx run

+ https://docs.efproject.net/en/latest/platforms/coreclr/getting-started-osx.html
+ http://docs.asp.net/en/latest/dnx/commands.html
+ https://msdn.microsoft.com/en-us/magazine/dn890367.aspx
+ http://stackoverflow.com/questions/29300777/is-there-an-entity-framework-7-database-first-poco-generator
+ http://docs.asp.net/en/latest/dnx/projects.html

## 03 (=c) 

    cp ../02-sqlite/blog.db ./
    dnu install EntityFramework.Sqlite.Design
    rm __EFMigrationsHistory.cs 
    rm blogContext.cs 
    rm Blog.cs 
    rm Post.cs
    dnx ef dbcontext scaffold Filename=$(realpath blog.db) EntityFramework.Sqlite

+ http://stackoverflow.com/questions/29300777/is-there-an-entity-framework-7-database-first-poco-generator
