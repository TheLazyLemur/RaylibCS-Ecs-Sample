FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TestEcs/TestEcs.csproj", "TestEcs/"]
RUN dotnet restore "TestEcs/TestEcs.csproj"
COPY . .
WORKDIR "/src/TestEcs"
RUN dotnet build "TestEcs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestEcs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestEcs.dll"]
