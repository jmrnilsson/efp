#!/bin/bash
echo "Setting VM, creating scaffold and running benchmarks"
rm __EFMigrationsHistory.cs; rm blogContext.cs; rm Blog.cs; rm Post.cs; rm ./blog.db;
cp ../02-sqlite/blog.db ./
mv ./Program.cs ./Program.cs_
dnx ef dbcontext scaffold Filename=$(realpath blog.db) EntityFramework.Sqlite
mv ./Program.cs_ ./Program.cs
dnx run