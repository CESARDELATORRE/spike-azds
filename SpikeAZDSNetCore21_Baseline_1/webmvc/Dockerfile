FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["webmvc/webmvc.csproj", "webmvc/"]

RUN dotnet restore "$PROJECT_DIR/webmvc.csproj"
COPY . .
WORKDIR "/src/webmvc"
RUN dotnet build "webmvc.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "webmvc.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "webmvc.dll"]