# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY OneWorld/*.csproj ./OneWorld/
RUN dotnet restore OneWorld/OneWorld.csproj

COPY OneWorld/. ./OneWorld/
RUN dotnet publish OneWorld/OneWorld.csproj -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish ./

ENTRYPOINT ["dotnet", "OneWorld.dll"]