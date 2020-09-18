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
    -p:PublishReadyToRun=true

FROM alpine:3.12 as runtime-machine
COPY --from=build-machine /app /app
# As we saw from the previous Dockerfile our container doesn't run! The reason is simple,
# our Alpine base image is so stripped down it doesn't have the libraries that .NET Core
# requires. The fix is simple, we just have to install the.

RUN apk update && apk add --no-cache libstdc++ libgcc libintl

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT true
WORKDIR /app
ENTRYPOINT ["./HelloWorld"]
# And the result: A 46MB image. However note that size before we added the required libs for
# .NET Core, the image was <6MB.  