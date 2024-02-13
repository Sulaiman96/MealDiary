FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MealDiary.API/MealDiary.API.csproj", "MealDiary.API/"]
RUN dotnet restore "MealDiary.API/MealDiary.API.csproj"
COPY . .
WORKDIR "/src/MealDiary.API"
RUN dotnet build "MealDiary.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MealDiary.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MealDiary.API.dll"]
