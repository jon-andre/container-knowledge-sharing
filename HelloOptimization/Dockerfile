# WARNING: To prove a point this Dockerfile will build an image, but
# if you try to run it you will get a bunch of errors! To get a working
# image use Dockerfile.optimize

# Personally I would use build-env or build instead of build-machine
# but I'm using build-machine as I think it clarifies the example.
# Note: build-machine is a custom tag, docker wouldn't care if you
# called it lol-containers.
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-machine
WORKDIR /
COPY /HelloWorld /HelloWorld
WORKDIR /HelloWorld
# So the following way of building our .NET Core app is not very effective:
# RUN dotnet publish -c release -o /app
# Building our app this way leaves us with a container at the whopping size
# of 400MB! Kinda excessive for a simple HelloWorld app right?
#
# The observant reader might have seen that we download the whole .NET Core
# SDK as our base image. This is really smart for building our app, but we
# don't need the SDK to run our code when it is finally built. So instead what
# we're going to do, is to build our app in a container that has the whole
# SDK installed and then pass the compiled program to a container that only 
# has the necessary runtimes/libraries installed.
RUN dotnet publish -c release -o /app

# Here we create a new container. Since these two containers are a part of the same 
# Dockerfile the result of our docker build command, will only be the last image though. 
FROM alpine:3.12 as runtime-machine
# The --from option tells Docker that this specific COPY should copy from the container
# build-machine and NOT our local machine (i.e your Windows/Mac)
COPY --from=build-machine /app /app

WORKDIR /app
ENTRYPOINT ["./HelloWorld"]