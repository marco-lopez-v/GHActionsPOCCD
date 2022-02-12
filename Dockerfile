#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
ENV ASPNETCORE_URLS http://*:44319
ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /source
COPY . .
RUN dotnet restore "./GHActionsPOCCD/GHActionsPOCCD.csproj" --disable-parallel
RUN dotnet publish "./GHActionsPOCCD/GHActionsPOCCD.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 80

ENTRYPOINT ["dotnet", "GHActionsPOCCD.dll"]
