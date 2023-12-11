FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 5242

COPY ["/src/Application/Application.csproj", "/src/Application/"]
COPY ["/src/Domain/Domain.csproj", "/src/Domain/"]
COPY ["/src/Infrastructure/Infrastructure.csproj", "/src/Infrastructure/"]
COPY ["/src/MVC/MVC.csproj", "/src/MVC/"]
RUN dotnet restore "/src/MVC/MVC.csproj"

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final-env

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MVC.dll"]