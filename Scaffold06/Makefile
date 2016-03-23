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
	rm -f ./P0.cs
	dnx ef dbcontext scaffold Filename=$(name) EntityFramework.Sqlite
	cp -f ./P0.cs_ ./P0.cs


db/blog.db:
	rm -rf ./db/
	mkdir ./db
	cp ../02-sqlite/blog.db ./db/


clean:
	rm -rf ./css
	rm -rf ./node_modules
	mkdir ./css
	rm -f __EFMigrationsHistory.cs
	rm -f blogContext.cs
	rm -f ModelContext.cs
	rm -f Blog.cs
	rm -f Post.cs
	rm -f ./db/blog.db;


setup: clean scaffold
	dnu restore
	dnu build --quiet
	npm install
	curl -OL https://github.com/dhg/Skeleton/releases/download/2.0.4/Skeleton-2.0.4.zip
	unzip -o Skeleton-2.0.4.zip -d ./css/ && rm ./Skeleton-2.0.4.zip



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

