# WARNING: To prove a point this Dockerfile will build an image, but
# if you try to run it you will get a bunch of errors! To get a working
# image use Dockerfile.optimize

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-machine
WORKDIR /
COPY . /HelloOptimization
WORKDIR /HelloOptimization

RUN dotnet publish -c release -o /app

# Here we create a new container. Since these two containers are a part of the same 
# Dockerfile the result of our docker build command, will only be the last image though. 
FROM alpine:3.12 as runtime-machine
# The --from option tells Docker that this specific COPY should copy from the container
# build-machine and NOT our local machine (i.e your Windows/Mac)
COPY --from=build-machine /app /app

WORKDIR /app
ENTRYPOINT ["./HelloWorld"]