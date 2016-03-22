#!/bin/bash
echo "Setting VM, creating scaffold and running benchmarks"
dnvm use 1.0.0-rc1-update1 -r coreclr
rm __EFMigrationsHistory.cs; rm blogContext.cs; rm Blog.cs; rm Post.cs; rm ./blog.db;
cp ../02-sqlite/blog.db ./
mv ./Program.cs ./Program.cs_
dnx ef dbcontext scaffold Filename=$(realpath blog.db) EntityFramework.Sqlite
mv ./Program.cs_ ./Program.cs
dnx run