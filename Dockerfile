# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy everything into the container
COPY . .

# Restore packages
RUN dotnet restore Wonderlust.sln

# Publish the API project
RUN dotnet publish Wonderlust.Api/Wonderlust.Api.csproj -c Release -o /app/publish

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy published output from build stage
COPY --from=build /app/publish .

# ASP.NET Core listens on port 8080 inside container
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Wonderlust.Api.dll"]
