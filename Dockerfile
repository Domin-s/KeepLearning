FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 5242

COPY ["/api/KeepLearning.Application/KeepLearning.Application.csproj", "/api/KeepLearning.Application/"]
COPY ["/api/KeepLearning.Domain/KeepLearning.Domain.csproj", "/api/KeepLearning.Domain/"]
COPY ["/api/KeepLearning.Infrastructure/KeepLearning.Infrastructure.csproj", "/api/KeepLearning.Infrastructure/"]
COPY ["/api/KeepLearning.MVC/KeepLearning.MVC.csproj", "/api/KeepLearning.MVC/"]
RUN dotnet restore "/api/KeepLearning.MVC/KeepLearning.MVC.csproj"

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final-env

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "KeepLearning.MVC.dll"]