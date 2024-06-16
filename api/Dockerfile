From  mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /api

COPY . ./ 

RUN dotnet restore

RUN dotnet publish -c Release -o publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /api

COPY --from=build-env /api/publish .

EXPOSE 80 80/tcp

ENTRYPOINT ["dotnet","api.dll"]
