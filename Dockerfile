FROM microsoft/aspnetcore:2
WORKDIR /app
COPY angular5dotnetcore2.0/dotnetcoreplusangular5Template/published  ./
RUN dotnet restore
# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet","dotnetcoreplusangular5Template.dll"]