#!/bin/bash
echo "Cleaning"
rm __EFMigrationsHistory.cs; rm blogContext.cs; rm Blog.cs; rm Post.cs; rm ./db/blog.db;
rm -rf ./node_modules/
echo "Done"