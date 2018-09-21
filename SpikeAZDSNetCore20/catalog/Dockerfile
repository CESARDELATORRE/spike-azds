FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["catalog/catalog.csproj", "catalog/"]

RUN dotnet restore "$PROJECT_DIR/catalog.csproj"
COPY . .
WORKDIR "/src/catalog"
RUN dotnet build "catalog.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "catalog.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "catalog.dll"]