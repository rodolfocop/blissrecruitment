#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY ["src/Bliss.API/Bliss.API.csproj", "src/Bliss.API/"]
COPY ["src/Bliss.Database/Bliss.Database.csproj", "src/Bliss.Database/"]
COPY ["src/Bliss.Domain/Bliss.Domain.csproj", "src/Bliss.Domain/"]
COPY ["src/Bliss.Model/Bliss.Model.csproj", "src/Bliss.Model/"]
COPY ["src/Bliss.Application/Bliss.Application.csproj", "src/Bliss.Application/"]
RUN dotnet restore "src/Bliss.API/Bliss.API.csproj"
COPY . .
WORKDIR "/src/Bliss.API"
RUN dotnet build "Bliss.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bliss.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bliss.API.dll"]
