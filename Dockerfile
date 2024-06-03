FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CollegeManagementSystem.API/CollegeManagementSystem.API.csproj", "CollegeManagementSystem.API/"]
COPY ["CollegeManagementSystem.Application/CollegeManagementSystem.Application.csproj", "CollegeManagementSystem.Application/"]
COPY ["CollegeManagementSystem.Domain/CollegeManagementSystem.Domain.csproj", "CollegeManagementSystem.Domain/"]
COPY ["SharedKernel/SharedKernel.csproj", "SharedKernel/"]
COPY ["SmartCollege.SSO.Shared/SmartCollege.SSO.Shared.csproj", "SmartCollege.SSO.Shared/"]
COPY ["SmartCollege.RabbitMQ.Contracts/SmartCollege.RabbitMQ.Contracts.csproj", "SmartCollege.RabbitMQ.Contracts/"]
COPY ["CollegeManagementSystem.Infrastucture/CollegeManagementSystem.Infrastucture.csproj", "CollegeManagementSystem.Infrastucture/"]
COPY ["CollegeManagementSystem.Infrastucture.MSSQL/CollegeManagementSystem.Infrastucture.MSSQL.csproj", "CollegeManagementSystem.Infrastucture.MSSQL/"]
COPY ["CollegeManagementSystem.Infrastucture.Common/CollegeManagementSystem.Infrastucture.Common.csproj", "CollegeManagementSystem.Infrastucture.Common/"]
COPY ["CollegeManagementSystem.Infrastucture.Postgres/CollegeManagementSystem.Infrastucture.Postgres.csproj", "CollegeManagementSystem.Infrastucture.Postgres/"]
RUN dotnet restore "./CollegeManagementSystem.API/CollegeManagementSystem.API.csproj"
COPY . .
WORKDIR "/src/CollegeManagementSystem.API"
RUN dotnet build "./CollegeManagementSystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CollegeManagementSystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollegeManagementSystem.API.dll"]