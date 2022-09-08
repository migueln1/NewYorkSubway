FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY ["NewYorkSubway/NewYorkSubway.csproj", "NewYorkSubway/"]
RUN dotnet restore "NewYorkSubway/NewYorkSubway.csproj"
COPY . .
WORKDIR "/NewYorkSubway"
RUN dotnet build "NewYorkSubway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NewYorkSubway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewYorkSubway.dll"]