FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /dotnetapp
COPY ./bin/Docker .
ENV ASPNETCORE_URLS http://*:5051
ENV ASPNETCORE_ENVIRONMENT docker
ENTRYPOINT dotnet Actio.Services.Identity.dll