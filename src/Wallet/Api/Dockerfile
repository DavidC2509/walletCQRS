#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Wallet/Api/Api.csproj", "src/Wallet/Api/"]
COPY ["src/Wallet/Services/Services.csproj", "src/Wallet/Services/"]
COPY ["src/Wallet/Command/Command.csproj", "src/Wallet/Command/"]
COPY ["core/CommandAndQueryHandler/CommandAndQueryHandler.csproj", "core/CommandAndQueryHandler/"]
COPY ["core/Domain/Domain.csproj", "core/Domain/"]
COPY ["src/Wallet/Domain/Domain.csproj", "src/Wallet/Domain/"]
RUN dotnet restore "src/Wallet/Api/Api.csproj"
COPY . .
WORKDIR "/src/src/Wallet/Api"
RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Template.Api.dll"]