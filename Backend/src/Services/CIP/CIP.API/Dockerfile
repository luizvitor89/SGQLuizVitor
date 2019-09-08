FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Services/CIP/CIP.API/CIP.API.csproj", "src/Services/CIP/CIP.API/"]
RUN dotnet restore "src/Services/CIP/CIP.API/CIP.API.csproj"
COPY . .
WORKDIR "/src/src/Services/CIP/CIP.API"
RUN dotnet build "CIP.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CIP.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CIP.API.dll"]
