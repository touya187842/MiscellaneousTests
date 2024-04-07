FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /src
COPY ["BenchmarkTests.csproj", "BenchmarkTests/"]
RUN dotnet restore "BenchmarkTests/BenchmarkTests.csproj"

COPY . "BenchmarkTests/"
WORKDIR "/src/BenchmarkTests"
RUN dotnet publish "./BenchmarkTests.csproj" -p:TargetFramework=net8.0 -p:DefineConstants=DOCKER

ENTRYPOINT ["dotnet", "./bin/Release/net8.0/publish/BenchmarkTests.dll"]
