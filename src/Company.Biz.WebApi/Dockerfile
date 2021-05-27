#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Company.Biz.WebApi/Company.Biz.WebApi.csproj", "src/Company.Biz.WebApi/"]
COPY ["src/Company.Biz.Infrastructure/Company.Biz.Infrastructure.csproj", "src/Company.Biz.Infrastructure/"]
COPY ["src/Company.Biz.Domain/Company.Biz.Domain.csproj", "src/Company.Biz.Domain/"]
RUN dotnet restore "src/Company.Biz.WebApi/Company.Biz.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Company.Biz.WebApi"
RUN dotnet build "Company.Biz.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Company.Biz.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Company.Biz.WebApi.dll"]