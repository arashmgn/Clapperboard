FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY Domain/IMDB.Domain.csproj Domain/
COPY Application/IMDB.Application.csproj Application/
COPY Infrastructure/IMDB.Infrastructure.csproj Infrastructure/
COPY api/IMDB.WebAPI.csproj api/
RUN dotnet restore api/IMDB.WebAPI.csproj

COPY Domain/ Domain/
COPY Application/ Application/
COPY Infrastructure/ Infrastructure/
COPY api/ api/
RUN dotnet publish api/IMDB.WebAPI.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "IMDB.WebAPI.dll"]
