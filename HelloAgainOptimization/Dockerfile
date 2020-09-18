FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-machine
WORKDIR /

COPY . /HelloWorld
WORKDIR /HelloWorld

RUN dotnet publish \ 
    -c release \ 
    -o /app \ 
    -r linux-musl-x64 \
    --self-contained true \
    -p:PublishTrimmed=true \
    -p:PublishSingleFile=true
    #-p:PublishReadyToRun=true

FROM alpine:3.12 as runtime-machine
COPY --from=build-machine /app /app

RUN apk update && apk add --no-cache libstdc++ libgcc libintl

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT true
WORKDIR /app
ENTRYPOINT ["./HelloWorld"]