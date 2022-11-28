#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Test.Quiz/Test.Quiz.csproj", "Test.Quiz/"]
COPY ["Application.Quiz/Application.Quiz.csproj", "Application.Quiz/"]
COPY ["Domain.Quiz/Domain.Quiz.csproj", "Domain.Quiz/"]
RUN dotnet restore "Test.Quiz/Test.Quiz.csproj"
COPY . .
WORKDIR "/src/Test.Quiz"
RUN dotnet build "Test.Quiz.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Test.Quiz.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test.Quiz.dll"]