FROM mcr.microsoft.com/dotnet/core/sdk:3.1.402-alpine3.12 AS build-machine
WORKDIR /
RUN mkdir -p /src 
RUN mkdir -p /app

COPY ConsoleUI /src/DemoApplication/ConsoleUI
COPY DemoLibrary /src/DemoApplication/DemoLibrary

RUN apk update && apk --no-cache add tzdata 

WORKDIR /src/DemoApplication/ConsoleUI
RUN dotnet publish -c Release -o /app \
    -p:PublishTrimmed=true \  
    -r linux-musl-x64 \
    --self-contained true

FROM mcr.microsoft.com/dotnet/core/runtime:3.1.8-alpine3.12 AS runtime-machine

COPY --from=build-machine /app /app

WORKDIR /app
ENTRYPOINT [ "./ConsoleUI" ]