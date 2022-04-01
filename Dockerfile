FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY *.sln .
COPY ["Net6Mvc/*.csproj", "Net6Mvc/"]
RUN dotnet restore ./Net6Mvc

COPY . .
RUN dotnet publish "Net6Mvc/Net6Mvc.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
RUN mkdir LogFiles
RUN chmod 777 LogFiles
EXPOSE 80
COPY --from=build /src/out ./
ENTRYPOINT ["dotnet", "Net6Mvc.dll"]