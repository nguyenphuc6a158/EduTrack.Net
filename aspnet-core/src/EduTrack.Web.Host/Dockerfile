FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/EduTrack.Web.Host/EduTrack.Web.Host.csproj", "src/EduTrack.Web.Host/"]
COPY ["src/EduTrack.Web.Core/EduTrack.Web.Core.csproj", "src/EduTrack.Web.Core/"]
COPY ["src/EduTrack.Application/EduTrack.Application.csproj", "src/EduTrack.Application/"]
COPY ["src/EduTrack.Core/EduTrack.Core.csproj", "src/EduTrack.Core/"]
COPY ["src/EduTrack.EntityFrameworkCore/EduTrack.EntityFrameworkCore.csproj", "src/EduTrack.EntityFrameworkCore/"]
WORKDIR "/src/src/EduTrack.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/EduTrack.Web.Host", "src/EduTrack.Web.Host"]
COPY ["src/EduTrack.Web.Core", "src/EduTrack.Web.Core"]
COPY ["src/EduTrack.Application", "src/EduTrack.Application"]
COPY ["src/EduTrack.Core", "src/EduTrack.Core"]
COPY ["src/EduTrack.EntityFrameworkCore", "src/EduTrack.EntityFrameworkCore"]
WORKDIR "/src/src/EduTrack.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "EduTrack.Web.Host.dll"]
