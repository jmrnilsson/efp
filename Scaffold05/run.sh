#!/bin/bash
echo "Setting VM, creating scaffold and running benchmarks"
rm __EFMigrationsHistory.cs; rm blogContext.cs; rm Blog.cs; rm Post.cs; rm ./db/blog.db;
cp ../02-sqlite/blog.db ./db/
mv ./Program.cs ./Program.cs_
dnx ef dbcontext scaffold Filename=$(realpath ./db/blog.db) EntityFramework.Sqlite
mv ./Program.cs_ ./Program.cs
npm install
npm start