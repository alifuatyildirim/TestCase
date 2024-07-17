FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TestCase.Api/TestCase.Api.csproj", "TestCase.Api/"]
RUN dotnet restore "TestCase.Api/TestCase.Api.csproj"
COPY . .
WORKDIR "/src/TestCase.Api"
RUN dotnet build "TestCase.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestCase.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestCase.Api.dll"]
