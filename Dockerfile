# Base stage for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["Items-Web-API.csproj", "."]
RUN dotnet restore "./Items-Web-API.csproj"
COPY . .

# Build the project
RUN dotnet build "./Items-Web-API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Install dotnet-ef tool for migrations
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Apply migrations during build
RUN dotnet ef database update --project /src/Items-Web-API.csproj

# Publish the application
RUN dotnet publish "./Items-Web-API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage for production
FROM base AS final
WORKDIR /app

# Copy published files to the final stage
COPY --from=build /app/publish .

# Set runtime entry point
ENTRYPOINT ["dotnet", "Items-Web-API.dll"]
