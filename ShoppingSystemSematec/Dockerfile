#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ShoppingSystemSematec/ShoppingSystemSematec.Api.csproj", "ShoppingSystemSematec/"]
COPY ["ShoppingSystemSematec.Application/ShoppingSystemSematec.Application.csproj", "ShoppingSystemSematec.Application/"]
COPY ["ShoppingSystemSematec.Domain/ShoppingSystemSematec.Domain.csproj", "ShoppingSystemSematec.Domain/"]
COPY ["ShoppingSystemSematec.Infrastructure.Identity/ShoppingSystemSematec.Infrastructure.Identity.csproj", "ShoppingSystemSematec.Infrastructure.Identity/"]
COPY ["ShoppingSystemSematec.Infrastructure/ShoppingSystemSematec.Infrastructure.csproj", "ShoppingSystemSematec.Infrastructure/"]
RUN dotnet restore "./ShoppingSystemSematec/./ShoppingSystemSematec.Api.csproj"
COPY . .
WORKDIR "/src/ShoppingSystemSematec"
RUN dotnet build "./ShoppingSystemSematec.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ShoppingSystemSematec.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingSystemSematec.Api.dll"]