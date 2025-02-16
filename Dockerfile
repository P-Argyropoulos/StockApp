FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5014

ENV ASPNETCORE_URLS=http://+:5014

USER app

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src
COPY api/ api/
RUN dotnet restore "api/api.csproj"

COPY . . 
WORKDIR "/src/api"
RUN dotnet build "api.csproj" -c $configuration -o /app/build
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.dll"]

