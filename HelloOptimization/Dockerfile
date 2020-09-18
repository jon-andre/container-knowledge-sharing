# WARNING: To prove a point this Dockerfile will build an image, but
# if you try to run it you will get a bunch of errors! To get a working
# image use Dockerfile.optimize

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-machine
WORKDIR /
COPY . /HelloOptimization
WORKDIR /HelloOptimization

#RUN dotnet publish -c release -o /app

RUN dotnet publish -c release -o /app 


# To avoid being proven a point you can use .
# FROM mcr.microsoft.com/dotnet/core/runtime:3.1.8-alpine3.12 AS runtime-machine
FROM alpine:3.12 as runtime-machine
COPY --from=build-machine /app /app

WORKDIR /app
ENTRYPOINT ["./HelloWorld"]