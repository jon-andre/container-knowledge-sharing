# We want the dotnet core 3.1 SDK and we want our container OS to be Alpine Linux.
# This means that from the container's perspectice the OS is Alpine Linux.
#
# The description behind the FROM keyword, is our base *image*. A container is
# a running instance of an image. This means you could say that a Dockerfile
# gets compiled to a, image. It isn't before we run this image, we have a container.
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine
WORKDIR /
COPY /HelloWorld /HelloWorld
WORKDIR /HelloWorld
RUN dotnet publish -c release -o /app
WORKDIR /app
ENTRYPOINT ["dotnet", "HelloWorld.dll"]