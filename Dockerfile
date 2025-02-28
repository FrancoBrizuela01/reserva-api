# Usa la imagen de .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ReservaApi.csproj", "./"]
RUN dotnet restore "./ReservaApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ReservaApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReservaApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReservaApi.dll"]
