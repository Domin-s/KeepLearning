FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 5242

#backend
COPY ["/backend/src/Application/Application.csproj", "/backend/src/Application/"]
COPY ["/backend/src/Domain/Domain.csproj", "/backend/src/Domain/"]
COPY ["/backend/src/Infrastructure/Infrastructure.csproj", "/backend/src/Infrastructure/"]
COPY ["/backend/src/API/API.csproj", "/backend/src/API/"]
RUN dotnet restore "/backend/src/API/API.csproj"

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final-env

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MVC.dll"]
