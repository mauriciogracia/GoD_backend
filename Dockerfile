# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

# copy csproj and restore as distinct layers
COPY /src/*.csproj ./
RUN dotnet restore ./GoD_backend.csproj

# copy and publish app and libraries
COPY /src/* .
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "GoD_backend.dll"]