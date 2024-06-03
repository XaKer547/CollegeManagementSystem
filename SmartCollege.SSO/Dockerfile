FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 7137
EXPOSE 5213

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SmartCollege.SSO/SmartCollege.SSO.csproj", "SmartCollege.SSO/"]
COPY ["SmartCollege.RabbitMQ.Contracts/SmartCollege.RabbitMQ.Contracts.csproj", "SmartCollege.RabbitMQ.Contracts/"]
COPY ["SmartCollege.SSO.Shared/SmartCollege.SSO.Shared.csproj", "SmartCollege.SSO.Shared/"]
RUN dotnet restore "./SmartCollege.SSO/SmartCollege.SSO.csproj"
COPY . .
WORKDIR "/src/SmartCollege.SSO"
RUN dotnet build "./SmartCollege.SSO.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SmartCollege.SSO.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartCollege.SSO.dll"]