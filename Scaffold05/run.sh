#!/bin/bash
echo "Cleaning..."
rm __EFMigrationsHistory.cs; rm blogContext.cs; rm Blog.cs; rm Post.cs; rm ./db/blog.db;
cp ../02-sqlite/blog.db ./db/
# mv ./Program.cs ./Program.cs_
mv ./P0.cs ./P0.cs_
echo "Creating scaffold..."
dnx ef dbcontext scaffold Filename=$(realpath ./db/blog.db) EntityFramework.Sqlite
# mv ./Program.cs_ ./Program.cs
mv ./P0.cs_ ./P0.cs
# npm install
echo "Starting app..."
npm start