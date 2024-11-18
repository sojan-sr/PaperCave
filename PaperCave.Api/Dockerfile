FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PaperCave.Api/PaperCave.Api.csproj", "PaperCave.Api/"]
COPY ["PaperCave.Infrastructure/PaperCave.Infrastructure.csproj", "PaperCave.Infrastructure/"]
COPY ["PaperCave.Models/PaperCave.Models.csproj", "PaperCave.Models/"]
COPY ["PaperCave.Services/PaperCave.Services.csproj", "PaperCave.Services/"]
RUN dotnet restore "PaperCave.Api/PaperCave.Api.csproj"
COPY . .
WORKDIR "/src/PaperCave.Api"
RUN dotnet build "PaperCave.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PaperCave.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaperCave.Api.dll"]
