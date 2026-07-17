FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["TaskManager.sln", "./"]
COPY ["TaskManagerStart/TaskManagerStart.csproj", "TaskManagerStart/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["UseCase/UseCase.csproj", "UseCase/"]

RUN dotnet restore "TaskManager.sln"

COPY . .

WORKDIR "/src/TaskManagerStart"
RUN dotnet build "TaskManagerStart.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskManagerStart.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "TaskManagerStart.dll"]