# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
COPY /src/* /GoD_build 
RUN dotnet publish -c release -o /GoD_back /GoD_build/GoD_backend.csproj

# final stage/image
FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR /GoD_build
COPY --from=build /GoD_back .
ENTRYPOINT ["dotnet", "GoD_backend.dll"]