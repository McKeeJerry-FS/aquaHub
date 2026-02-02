# Base stage for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy MSBuild override file first
COPY ["AquaHub/Directory.Build.props", "AquaHub/"]

# Copy project file for restore
COPY ["AquaHub/AquaHub.csproj", "AquaHub/"]

# Restore packages
RUN dotnet restore "AquaHub/AquaHub.csproj"

# Copy all source files
COPY ["AquaHub/", "AquaHub/"]

# Publish directly (which includes build)
WORKDIR "/src/AquaHub"
RUN dotnet publish "AquaHub.csproj" -c Release -o /app/publish \
    /p:UseAppHost=false \
    /p:EnableDefaultEmbeddedResourceItems=false \
    /p:EnableDefaultItems=true \
    /p:GenerateResourceUsePreserializedResources=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Set environment for Railway
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}

ENTRYPOINT ["dotnet", "AquaHub.dll"]






