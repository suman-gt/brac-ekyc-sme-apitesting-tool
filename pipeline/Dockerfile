FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY . .
RUN dotnet restore 'APITestingTool/APITestingTool.csproj'
RUN dotnet publish 'APITestingTool/APITestingTool.csproj' -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

RUN ln -s /shared_storage /app/shared
COPY --from=build /app/out .
COPY APITestingTool/* /app/

EXPOSE 5000
ENTRYPOINT ["dotnet", "APITestingTool.dll"]
