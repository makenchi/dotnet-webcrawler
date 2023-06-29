# Base image
FROM mcr.microsoft.com/dotnet/core/sdk:6.2.3 AS build-env

# Set the working directory
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the source code and build the application
COPY . ./
RUN dotnet build -c Release --no-restore

# Expose the port
EXPOSE 5000

# Set the entry point for the application
ENTRYPOINT ["dotnet", "run", "--no-build", "--urls", "http://0.0.0.0:5000"]
