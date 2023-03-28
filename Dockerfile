#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Paramo.Api/Paramo.Api.csproj", "Paramo.Api/"]
COPY ["Paramo.Classes/Paramo.Classes.csproj", "Paramo.Classes/"]
RUN dotnet restore "Paramo.Api/Paramo.Api.csproj"
COPY . .
WORKDIR "/src/Paramo.Api"
RUN dotnet build "Paramo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Paramo.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Paramo.Api.dll"]