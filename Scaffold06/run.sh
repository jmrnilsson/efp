#!/bin/bash
echo "Cleaning..."
rm __EFMigrationsHistory.cs; rm blogContext.cs; rm Blog.cs; rm Post.cs; rm ./db/blog.db;
cp ../02-sqlite/blog.db ./db/
curl -OL https://github.com/dhg/Skeleton/releases/download/2.0.4/Skeleton-2.0.4.zip
mkdir ./css
unzip -o Skeleton-2.0.4.zip -d ./css/ && rm ./Skeleton-2.0.4.zip
mv ./P0.cs ./P0.cs_
echo "Creating scaffold..."
dnx ef dbcontext scaffold Filename=$(realpath ./db/blog.db) EntityFramework.Sqlite
mv ./P0.cs_ ./P0.cs
npm install
echo "Starting app..."
npm start