#!/bin/bash

cd angular5dotnetcore2.0/dotnetcoreplusangular5Template
dotnet publish -c Release -o published

cd ../../../
docker build -t spartha1995/angular5dotnetcore2.0
docker login -u=$Docker_UserName -p=$Docker_Password
docker push spartha1995/angular5dotnetcore2.0