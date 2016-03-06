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
    dnu restore
    dnu build --quiet

+ https://docs.efproject.net/en/latest/platforms/coreclr/getting-started-osx.html
+ http://docs.asp.net/en/latest/dnx/commands.html
