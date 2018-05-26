#!/bin/bash
set -ev

# Create publish artifact
dotnet publish -c Release ./angular5dotnetcore2.0/dotnetcoreplusangular5Template.sln

# Login to Docker Hub and upload images
docker login -u $Docker_UserName -p $Docker_Password
docker build --no-cache -t $Docker_Repo .
docker tag $Docker_Repo:latest $Docker_Repo:$TRAVIS_BRANCH
docker push $Docker_Repo
OpenShift user: partha.sarathi.sarkar95@gmail.com
OpenShift password: $Docker_Password
OpenShift application name: |demo|
OpenShift domain: http://demo-angular2.a3c1.starter-us-west-1.openshiftapps.com/
Deploy only from <USER>/myapp? |yes| 
Encrypt password? |yes|
