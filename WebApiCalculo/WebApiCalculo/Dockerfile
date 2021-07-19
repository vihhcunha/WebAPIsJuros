FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 444

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app
COPY ["WebApiCalculo/WebApiCalculo/WebApiCalculo.csproj", "WebApiCalculo/WebApiCalculo/"]
COPY ["Domain/CalculoJuros.Domain/CalculoJuros.Domain.csproj", "Domain/CalculoJuros.Domain/"]
COPY ["CrossCutting/CrossCutting.ConsumoAPI/CrossCutting.ConsumoAPI.csproj", "CrossCutting/CrossCutting.ConsumoAPI/"]
COPY ["Tests/CalculoJuros.Domain.Tests/CalculoJuros.Domain.Tests.csproj", "Tests/CalculoJuros.Domain.Tests/"]
RUN dotnet restore "WebApiCalculo/WebApiCalculo/WebApiCalculo.csproj"
COPY . .
RUN dotnet test "Tests/CalculoJuros.Domain.Tests/CalculoJuros.Domain.Tests.csproj" -c Release
WORKDIR "/app/WebApiCalculo/WebApiCalculo"
RUN dotnet build -c Release
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/WebApiCalculo/WebApiCalculo/out .
ENTRYPOINT [ "dotnet", "WebApiCalculo.dll", "test" ]