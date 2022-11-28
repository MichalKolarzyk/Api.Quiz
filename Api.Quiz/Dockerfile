#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api.Quiz/Api.Quiz.csproj", "Api.Quiz/"]
COPY ["Application.Quiz/Application.Quiz.csproj", "Application.Quiz/"]
COPY ["Domain.Quiz/Domain.Quiz.csproj", "Domain.Quiz/"]
COPY ["Infrastructure.Quiz/Infrastructure.Quiz.csproj", "Infrastructure.Quiz/"]
COPY ["BaseImplementationLib/BaseImplementationLib.csproj", "BaseImplementationLib/"]
RUN dotnet restore "Api.Quiz/Api.Quiz.csproj"
COPY . .
WORKDIR "/src/Api.Quiz"
RUN dotnet build "Api.Quiz.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Quiz.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Quiz.dll"]