FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NewYorkSubway/NewYorkSubway.csproj", "NewYorkSubway/"]
COPY ["NewYorkSubway.Application/NewYorkSubway.Application.csproj", "NewYorkSubway.Application/"]
COPY ["NewYorkSubway.Core/NewYorkSubway.Core.csproj", "NewYorkSubway.Core/"]
COPY ["NewYorkSubway.Infrastructure/NewYorkSubway.Infrastructure.csproj", "NewYorkSubway.Infrastructure/"]
COPY ["NewYorkSubway.Common/NewYorkSubway.Common.csproj", "NewYorkSubway.Common/"]
RUN dotnet restore "NewYorkSubway/NewYorkSubway.csproj"
COPY . .
WORKDIR "/src/NewYorkSubway"
RUN dotnet build "NewYorkSubway.csproj" -c Release -o /app/build

FROM build AS publish
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_14.x | bash \
    && apt-get install nodejs -yq
RUN dotnet publish "NewYorkSubway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewYorkSubway.dll"]
