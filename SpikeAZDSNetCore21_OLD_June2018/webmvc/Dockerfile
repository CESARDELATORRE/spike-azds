FROM microsoft/aspnetcore:2.1 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.1 AS build
WORKDIR /src
COPY SpikeAZDSNetCore21.sln ./
COPY webmvc/webmvc.csproj webmvc/

RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/webmvc
RUN dotnet build webmvc.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish webmvc.csproj -c Release -o /app

FROM base AS final
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "webmvc.dll"]
