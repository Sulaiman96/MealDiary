FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MealDiary/MealDiary.csproj", "MealDiary/"]
RUN dotnet restore "MealDiary/MealDiary.csproj"
COPY . .
WORKDIR "/src/MealDiary"
RUN dotnet build "MealDiary.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MealDiary.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MealDiary.dll"]
