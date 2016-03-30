######################################################
## Defaults
######################################################

SHELL=bash

######################################################
## Setup
######################################################

.PHONY: clean setup scaffold

scaffold: db/blog.db
	echo 'Generating scaffold from database schema..'
	rm -f ./dotnet/P0.cs
	(cd dotnet; dnx ef dbcontext scaffold Filename=$(realpath ./db/blog.db) EntityFramework.Sqlite)


db/blog.db:
	echo 'Copying database..'
	rm -rf ./db/
	mkdir ./db
	cp ../02-sqlite/blog.db ./db/


clean:
	echo 'Cleaning..'
	rm -rf ./curl
	mkdir ./curl
	rm -rf ./node_modules
	rm -rf ./dotnet/*.cs


setup: clean scaffold
	echo 'Getting dependencies..'
	dnu restore
	cp ./dotnet/Program.cs.003 ./dotnet/P0.cs
	(cd ./dotnet/; dnu build --quiet)
	npm install
	curl -OL https://github.com/dhg/Skeleton/releases/download/2.0.4/Skeleton-2.0.4.zip
	unzip -o Skeleton-2.0.4.zip -d ./curl/ && rm ./Skeleton-2.0.4.zip
	curl -OL http://knockoutjs.com/downloads/knockout-3.4.0.js
	mv knockout-3.4.0.js ./curl/
	curl -OL https://fortawesome.github.io/Font-Awesome/assets/font-awesome-4.5.0.zip
	unzip -o font-awesome-4.5.0.zip -d ./curl/ && rm ./font-awesome-4.5.0.zip


######################################################
## Testing
######################################################

.PHONY: lint

lint:
	echo 'Executing linter..'
	node_modules/.bin/eslint ./*.js


######################################################
## Running
######################################################

.PHONY: run

run:
	@ echo 'Running..'
	# @ curl -L https://fonts.googleapis.com/css?family=Raleway:400,300,600 > ./curl/raleway.css
	@ npm start