#!/bin/bash
set -ev

# Create publish artifact
dotnet publish -c Release src

# Build the Docker images
docker build -t repository/project:$Tag src/bin/Release/netcoreapp1.0/publish/.
docker tag repository/project:$Tag repository/project:latest

# Login to Docker Hub and upload images
docker login -u="$Docker_UserName" -p="$Docker_Password"
docker push repository/project:$Tag
docker push repository/project:latest