FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS base
WORKDIR /app
RUN apt-get update
RUN apt-get install -y software-properties-common
RUN apt-get update
RUN apt-get install -y telnet
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS publish
WORKDIR /src
COPY ["/TestDocker/", "/TestDocker/"]
RUN dotnet restore "/TestDocker/TestDocker.csproj"
RUN dotnet publish "/TestDocker/TestDocker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestDocker.dll"]
