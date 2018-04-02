#!/bin/bash
set -ev

# Create publish artifact
dotnet publish -c Release src

# Build the Docker images
docker build -t $Docker_Repo:$Tag src/bin/Release/netcoreapp1.0/publish/.
docker tag $Docker_Repo:$Tag $Docker_Repo:latest

# Login to Docker Hub and upload images
docker login -u="$Docker_UserName" -p="$Docker_Password"
docker push $Docker_Repo:$Tag
docker push $Docker_Repo:latest