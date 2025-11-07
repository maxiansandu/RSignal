# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiem tot codul sursă
COPY . .

# Restaurăm dependințele folosind fișierul soluției
RUN dotnet restore "UTM_Chat.sln"

# Compilăm proiectul Web
RUN dotnet publish "UTM_Chat.Web/UTM_Chat.Web.csproj" -c Release -o /app/out

# Etapa 2: Runtime (imagine mai mică)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Port implicit (Render/Fly.io)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "UTM_Chat.Web.dll"]
