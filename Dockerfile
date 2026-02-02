# Use the official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copy solution and all project files
COPY aquaHub.sln ./
COPY AquaHub/ ./AquaHub/
COPY AquaHub.Shared/ ./AquaHub.Shared/

# Build and publish the web app
WORKDIR /app/AquaHub
RUN dotnet publish -c Release -o /app/publish \
  /p:UseAppHost=false \
  /p:EnableDefaultEmbeddedResourceItems=false

# Use the ASP.NET runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/publish .

# Expose the port that Railway expects
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}
EXPOSE 8080

# Set the entry point
ENTRYPOINT ["dotnet", "AquaHub.dll"]
