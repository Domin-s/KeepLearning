FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /src
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/KeepLearning.Application/KeepLearning.Application.csproj", "src/KeepLearning.Application/"]
COPY ["src/KeepLearning.Domain/KeepLearning.Domain.csproj", "src/KeepLearning.Domain/"]
COPY ["src/KeepLearning.Infrastructure/KeepLearning.Infrastructure.csproj", "src/KeepLearning.Infrastructure/"]
COPY ["src/KeepLearning.MVC/KeepLearning.MVC.csproj", "src/KeepLearning.MVC/"]
COPY *.config .

WORKDIR /src
RUN dotnet restore "src/KeepLearning.MVC/KeepLearning.MVC.csproj" --disable-parallel --configfile ./nuget.config 
COPY . .

WORKDIR "/src/KeepLearning.MVC"
ENV ASPNETCORE_ENVIRONMENT="production"
RUN dotnet build "KeepLearning.MVC.csproj" -c Release -o /src/build
FROM build AS publish
RUN dotnet publish "KeepLearning.MVC.csproj" -c Release -o /src/publish
FROM base AS final

WORKDIR /src


COPY --from=publish /src/publish .
ENTRYPOINT ["dotnet", "KeepLearning.MVC.dll"]