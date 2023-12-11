FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 5242

COPY ["/src/KeepLearning.Application/KeepLearning.Application.csproj", "/src/KeepLearning.Application/"]
COPY ["/src/KeepLearning.Domain/KeepLearning.Domain.csproj", "/src/KeepLearning.Domain/"]
COPY ["/src/KeepLearning.Infrastructure/KeepLearning.Infrastructure.csproj", "/src/KeepLearning.Infrastructure/"]
COPY ["/src/KeepLearning.MVC/KeepLearning.MVC.csproj", "/src/KeepLearning.MVC/"]
RUN dotnet restore "/src/KeepLearning.MVC/KeepLearning.MVC.csproj"

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final-env

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "KeepLearning.MVC.dll"]