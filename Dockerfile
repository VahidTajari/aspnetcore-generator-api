#Build stage
FROM  mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /generator

#restore
COPY api/api.csproj ./api/
RUN dotnet restore api/api.csproj
COPY tests/tests.csproj ./tests/
RUN dotnet restore tests/tests.csproj
  
#copy src
COPY . .

#test
RUN dotnet test tests/tests.csproj

#pulish
RUN dotnet publish api/api.csproj -o /publish

#Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
COPY --from=build-env /publish /publish
WORKDIR /publish
EXPOSE 80 80/tcp
ENTRYPOINT ["dotnet","api.dll"]