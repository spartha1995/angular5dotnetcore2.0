FROM microsoft/aspnetcore:2
WORKDIR /app
COPY angular5dotnetcore2.0/dotnetcoreplusangular5Template/published  ./
RUN dotnet restore --configfile ../NuGet.Config
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet","dotnetcoreplusangular5Template.dll"]