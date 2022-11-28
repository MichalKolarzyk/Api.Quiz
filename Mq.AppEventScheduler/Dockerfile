#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Mq.AppEventScheduler/Mq.AppEventScheduler.csproj", "Mq.AppEventScheduler/"]
COPY ["BaseImplementationLib/BaseImplementationLib.csproj", "BaseImplementationLib/"]
RUN dotnet restore "Mq.AppEventScheduler/Mq.AppEventScheduler.csproj"
COPY . .
WORKDIR "/src/Mq.AppEventScheduler"
RUN dotnet build "Mq.AppEventScheduler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mq.AppEventScheduler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mq.AppEventScheduler.dll"]