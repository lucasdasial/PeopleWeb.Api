FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PeopleWeb.Api/PeopleWeb.Api.csproj", "PeopleWeb.Api/"]
RUN dotnet restore "PeopleWeb.Api/PeopleWeb.Api.csproj"
COPY . .
WORKDIR "/src/PeopleWeb.Api"
RUN dotnet build "./PeopleWeb.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PeopleWeb.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PeopleWeb.Api.dll"]
