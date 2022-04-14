FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/WASM/WASM.csproj", "src/WASM/"]
COPY ["src/Application/Application.csproj", "src/Application/"]
COPY ["src/CoreBusiness/CoreBusiness.csproj", "src/CoreBusiness/"]
RUN dotnet restore "src/WASM/WASM.csproj"
COPY . .
WORKDIR "/src/src/WASM"
RUN dotnet build "WASM.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WASM.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY ["src/WASM/nginx.conf", "/etc/nginx/nginx.conf"]