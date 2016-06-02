#!/bin/sh -x
ls . | grep -v Program.cs | grep .cs | xargs rm
