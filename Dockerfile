# Base stage for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy solution and project files
COPY ["AquaHub.Web.sln", "./"]
COPY ["AquaHub/AquaHub.csproj", "AquaHub/"]
COPY ["AquaHub.Shared/AquaHub.Shared.csproj", "AquaHub.Shared/"]

# Restore packages
RUN dotnet restore "AquaHub.Web.sln"

# Copy all source files
COPY . .

# Build the main project
WORKDIR "/src/AquaHub"
RUN dotnet build "AquaHub.csproj" -c $BUILD_CONFIGURATION -o /app/build --no-restore

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AquaHub.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false --no-restore

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set environment for Railway
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}

ENTRYPOINT ["dotnet", "AquaHub.dll"]






