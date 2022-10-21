#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Meetup.Migrator/Meetup.Migrator.csproj", "src/Meetup.Migrator/"]
COPY ["src/Meetup.DataLayer/Meetup.DataLayer.csproj", "src/Meetup.DataLayer/"]
COPY ["src/Meetup.BusinessLayer/Meetup.BusinessLayer.csproj", "src/Meetup.BusinessLayer/"]
RUN dotnet restore "src/Meetup.Migrator/Meetup.Migrator.csproj"
COPY . .
WORKDIR "/src/src/Meetup.Migrator"
RUN dotnet build "Meetup.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Meetup.Migrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Meetup.Migrator.dll", "--connection-string-source", "env", "--connection-string-env-variable-name", "MeetupService_ConnectionStrings__MeetingDB"]