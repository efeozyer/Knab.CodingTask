FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Knab.Api/Knab.Api.csproj", "Knab.Api/"]
RUN dotnet restore "src/Knab.Api/Knab.Api.csproj"
COPY . .
WORKDIR "/src/Knab.Api"
RUN dotnet build "Knab.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Knab.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Knab.Api.dll"]
