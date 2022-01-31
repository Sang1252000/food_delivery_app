#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["food_delivery_app_api/food_delivery_app_api.csproj", "food_delivery_app_api/"]
RUN dotnet restore "food_delivery_app_api/food_delivery_app_api.csproj"
COPY . .
WORKDIR "/src/food_delivery_app_api"
RUN dotnet build "food_delivery_app_api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "food_delivery_app_api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "food_delivery_app_api.dll"]