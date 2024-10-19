# FROM mcr.microsoft.com/dotnet/aspnet:5.0
# WORKDIR /app
# COPY ./app .
# COPY ./appsettings.json appsettings.json
# EXPOSE 8012
# ENTRYPOINT ["dotnet", "Demo.QLTS.Api.dll"]




# Use the official .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy the rest of the application code
COPY . ./

# Copy the .csproj file and restore dependencies
RUN dotnet restore Demo.QLTS.sln

# Build the application
RUN dotnet publish Demo.QLTS.sln -c Release -o out 

# Use the official ASP.NET Core runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copy the built application from the build stage
COPY --from=build /app/out ./

# Expose the port the app will run on
EXPOSE 80

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "Demo.QLTS.Api.dll"]


