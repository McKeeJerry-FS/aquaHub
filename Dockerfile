# Use the official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copy solution file and project files
COPY aquaHub.sln ./
COPY AquaHub/AquaHub.csproj ./AquaHub/
COPY AquaHub.Shared/AquaHub.Shared.csproj ./AquaHub.Shared/

# Restore dependencies for web app only
RUN dotnet restore AquaHub/AquaHub.csproj

# Copy the source code for web app and shared library only
COPY AquaHub/ ./AquaHub/
COPY AquaHub.Shared/ ./AquaHub.Shared/

# Build and publish the web app
WORKDIR /app/AquaHub
RUN dotnet publish -c Release -o /app/publish --no-restore

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
