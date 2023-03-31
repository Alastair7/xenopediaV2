#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Xenopedia.Service/Xenopedia.Service.csproj", "Services/Xenopedia.Service/"]
COPY ["Business/Xenopedia.Business/Xenopedia.Business.csproj", "Business/Xenopedia.Business/"]
COPY ["Commons/Xenopedia.Commons/Xenopedia.Commons.csproj", "Commons/Xenopedia.Commons/"]
COPY ["Entities/Xenopedia.Entities/Xenopedia.Entities.csproj", "Entities/Xenopedia.Entities/"]
COPY ["Infrastructure/Xenopedia.Infrastructure/Xenopedia.Infrastructure.csproj", "Infrastructure/Xenopedia.Infrastructure/"]
RUN dotnet restore "Services/Xenopedia.Service/Xenopedia.Service.csproj"
COPY . .
WORKDIR "/src/Services/Xenopedia.Service"
RUN dotnet build "Xenopedia.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Xenopedia.Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Xenopedia.Service.dll"]