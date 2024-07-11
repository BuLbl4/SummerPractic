FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TrafficLaws/TrafficLaws.csproj", "TrafficLaws/"]
RUN dotnet restore "TrafficLaws/TrafficLaws.csproj"
COPY . .
WORKDIR "/src/TrafficLaws"
RUN dotnet build "TrafficLaws.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TrafficLaws.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrafficLaws.dll"]
