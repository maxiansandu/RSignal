# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /chat

# Copiem fișierele proiectului
COPY *.csproj ./
RUN dotnet restore

# Copiem restul codului
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime (imagine mai mică)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /chat
COPY --from=build /app/out .

# Expune portul pentru host
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Punctul de start al aplicației
ENTRYPOINT ["dotnet", "chat.dll"]
