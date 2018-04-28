# .NET Core on Apprenda
FROM microsoft/aspnetcore:2
WORKDIR /app
COPY angular5dotnetcore2.0/dotnetcoreplusangular5Template/published  ./
EXPOSE 8085/tcp
ENV ASPNETCORE_URLS http://*:8085
ENTRYPOINT ["dotnet","dotnetcoreplusangular5Template.dll"]
