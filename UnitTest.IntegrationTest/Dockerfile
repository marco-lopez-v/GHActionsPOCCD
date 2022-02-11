#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UnitTest.IntegrationTest/UnitTest.IntegrationTest.csproj", "UnitTest.IntegrationTest/"]
COPY ["GHActionsPOCCD/GHActionsPOCCD.csproj", "GHActionsPOCCD/"]
RUN dotnet restore "UnitTest.IntegrationTest/UnitTest.IntegrationTest.csproj"
COPY . .
WORKDIR "/src/UnitTest.IntegrationTest"
RUN dotnet build "UnitTest.IntegrationTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnitTest.IntegrationTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnitTest.IntegrationTest.dll"]