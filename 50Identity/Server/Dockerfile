#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["50Identity/Server/Identity50.Server.csproj", "50Identity/Server/"]
COPY ["50Identity/Client/Identity50.Client.csproj", "50Identity/Client/"]
COPY ["50Identity/Shared/Identity50.Shared.csproj", "50Identity/Shared/"]
RUN dotnet restore "50Identity/Server/Identity50.Server.csproj"
COPY . .
WORKDIR "/src/50Identity/Server"
RUN dotnet build "Identity50.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity50.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity50.Server.dll"]