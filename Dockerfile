FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY . . 

RUN dotnet restore "CollegeManagementSystem.API/CollegeManagementSystem.API.csproj"

COPY . .

FROM build AS publish
WORKDIR "CollegeManagementSystem.API"
RUN dotnet publish "CollegeManagementSystem.API.csproj" --no-restore -c Release -o /app/publish /p:UseAppHost=true

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 7096
EXPOSE 5087

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollegeManagementSystem.API.dll"]