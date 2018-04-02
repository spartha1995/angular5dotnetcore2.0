#!/bin/bash
set -ev

# Create publish artifact
dotnet publish -c Release ./angular5dotnetcore2.0/dotnetcoreplusangular5Template.sln

# Login to Docker Hub and upload images
docker login -u $Docker_UserName -p $Docker_Password
docker build --no-cache -t $Docker_Repo .
docker tag $Docker_Repo:latest $Docker_Repo:v1
docker push $Docker_Repo