FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY WeatherWatch.Data.sln .
COPY WeatherWatch.Data/*.csproj ./WeatherWatch.Data/
COPY WeatherWatch.Domain/*.csproj ./WeatherWatch.Domain/
RUN dotnet restore

COPY . .
RUN dotnet publish WeatherWatch.Data.sln -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "WeatherWatch.Data.dll"]
