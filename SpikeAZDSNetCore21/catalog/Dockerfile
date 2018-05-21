FROM microsoft/aspnetcore:2.1 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.1 AS build
WORKDIR /src
COPY SpikeAZDSNetCore21.sln ./
COPY catalog/catalog.csproj catalog/

RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/catalog
RUN dotnet build catalog.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish catalog.csproj -c Release -o /app

FROM base AS final
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "catalog.dll"]
