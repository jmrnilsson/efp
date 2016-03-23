######################################################
## Defaults
######################################################

SHELL=bash
name = $(realpath ./db/blog.db)

######################################################
## Setup
######################################################

.PHONY: clean setup scaffold

scaffold: db/blog.db
	rm -f ./dotnet/P0.cs
	(cd dotnet; dnx ef dbcontext scaffold Filename=$(realpath ./db/blog.db) EntityFramework.Sqlite)


db/blog.db:
	rm -rf ./db/
	mkdir ./db
	cp ../02-sqlite/blog.db ./db/


clean:
	rm -rf ./curl
	rm -rf ./node_modules
	mkdir ./curl
	rm -f __EFMigrationsHistory.cs
	rm -f blogContext.cs
	rm -f ModelContext.cs
	rm -f Blog.cs
	rm -f Post.cs
	rm -f ./db/blog.db;


setup: clean scaffold
	dnu restore
	cp ./dotnet/Program.cs.001 ./dotnet/P0.cs
	(cd ./dotnet/; dnu build --quiet)
	npm install
	curl -OL https://github.com/dhg/Skeleton/releases/download/2.0.4/Skeleton-2.0.4.zip
	unzip -o Skeleton-2.0.4.zip -d ./curl/ && rm ./Skeleton-2.0.4.zip
	curl -OL http://knockoutjs.com/downloads/knockout-3.4.0.js
	mv knockout-3.4.0.js ./curl/



######################################################
## Testing
######################################################


######################################################
## Running
######################################################

.PHONY: run

run:
	@ echo "Running"
	@ npm start

