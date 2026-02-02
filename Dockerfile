# Use the official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file (web projects only) and project files
COPY ["AquaHub.Web.sln", "./"]
COPY ["AquaHub/AquaHub.csproj", "AquaHub/"]
COPY ["AquaHub.Shared/AquaHub.Shared.csproj", "AquaHub.Shared/"]

# Restore packages using the solution file
RUN dotnet restore "AquaHub.Web.sln"

# Copy everything else
COPY ["AquaHub/", "AquaHub/"]
COPY ["AquaHub.Shared/", "AquaHub.Shared/"]

# Build and publish
RUN dotnet publish "AquaHub/AquaHub.csproj" -c Release -o /app/publish

# Use the ASP.NET runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/publish .

# Expose the port that Railway expects
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}
EXPOSE 8080

# Set the entry point
ENTRYPOINT ["dotnet", "AquaHub.dll"]
