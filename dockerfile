FROM mcr.microsoft.com/dotnet/core/sdk:3.1

WORKDIR /source
COPY . .
RUN dotnet restore
RUN dotnet publish -c release -o /app-asset
EXPOSE 80
WORKDIR /app-asset
ENV ASPNETCORE_URLS http://*:80
CMD dotnet EDSE.Asset.Api.dll