# efp

## 01 - hello

    dnvm list
    dnvm use 1.0.0-rc2-16551 -r mono
    dnu restore
    dnvm use 1.0.0-rc2-16551 -r coreclr
    dnx run

+ https://github.com/dotnet/coreclr/blob/master/Documentation/install/get-dotnetcore-dnx-osx.md

## 02 - code first

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


## 03 - db first (=Scaffold)

    cp ../02-sqlite/blog.db ./
    dnu install EntityFramework.Sqlite.Design
    rm __EFMigrationsHistory.cs
    rm blogContext.cs
    rm Blog.cs
    rm Post.cs
    dnx ef dbcontext scaffold Filename=$(realpath blog.db) EntityFramework.Sqlite
    dnu build --quiet
    dnx run
    mkdir pub
    dnu publish --no-source --out ./pub

+ http://stackoverflow.com/questions/29300777/is-there-an-entity-framework-7-database-first-poco-generator
+ http://docs.asp.net/en/latest/dnx/projects.html
+ https://github.com/aspnet/Home/issues/590

Example..

    $ dnvm use 1.0.0-rc1-update1 -r coreclr
    $ dnx run
    Starting...

    Read 950 records in 577643 μs
    Assigned expression in 533733 μs
    Scan in 371 μs
    Enumerate next in 15 μs
    Index 5 in 0.22 μs
    Total time was 1111761 μs

## 04 - db first - vanilla

    dnvm use 1.0.0-rc1-update1 -r coreclr
    ./run.sh

## 05 electron

    dnvm use 1.0.0-rc1-update1 -r coreclr
    ./run.sh

+ http://electron.atom.io/docs/v0.37.2/api/ipc-main/

## 06 - cleanup, linting, styling

    dnvm use 1.0.0-rc1-update1 -r coreclr
    make setup
    make run
    
## 07 - dotnet core

## 08 - db generation + scaffolding
    
+ http://www.w3schools.com/css/tryit.asp?filename=trycss_table_padding

### Goals: 
+ Binding
+ Code structure
+ Slight clean-up
+ Interop
+ make setup, clean, run, scaffold (temporary) 
+ curl (or wget or git clone) unmanaged external dependencies

### Libs and tools 
+ Skeleton
+ ~~Rivets~~
+ Vue.js
+ https://codemirror.net/
+ eslint

## x dotnet
+ http://sethjuarez.com/2010/06/30/what-is-machine-learning/
+ http://numl.net/getting-started/


## 7 omnisharp
