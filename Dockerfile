FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Uschopchik.Web/Uschopchik.Web.csproj", "Uschopchik.Web/"]
RUN dotnet restore "Uschopchik.Web/Uschopchik.Web.csproj"
WORKDIR "/src/Uschopchik.Web"
COPY . .
RUN dotnet build "Uschopchik.Web/Uschopchik.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Uschopchik.Web/Uschopchik.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Uschopchik.Web.dll