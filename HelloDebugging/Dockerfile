FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine
WORKDIR /
COPY . /HelloWorld
WORKDIR /HelloWorld
RUN dotnet publish -c release -o /app
WORKDIR /
# On other container OSes than Alpine try /bin/bash
ENTRYPOINT ["/bin/sh"]