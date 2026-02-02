# Base stage for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files for restore
COPY ["AquaHub/AquaHub.csproj", "AquaHub/"]
COPY ["AquaHub.Shared/AquaHub.Shared.csproj", "AquaHub.Shared/"]

# Restore packages
RUN dotnet restore "AquaHub/AquaHub.csproj"

# Copy source files
COPY ["AquaHub/", "AquaHub/"]
COPY ["AquaHub.Shared/", "AquaHub.Shared/"]

# Build the main project
WORKDIR "/src/AquaHub"
RUN dotnet build "AquaHub.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AquaHub.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set environment for Railway
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}

ENTRYPOINT ["dotnet", "AquaHub.dll"]






