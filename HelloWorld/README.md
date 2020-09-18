# Hello World

So this sample goes through a basic Dockerfile and how to build an image from your code, and then run the image as a container. 

Lets go through the Dockerfile step-wise

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine
Here we pick our base image. That means we don't have to start from scratch. Our base image is one provided by Microsoft, while Microsoft's base image is the Alpine Linux base image. On top of Alpine, MS have set up everything we need to use the .NET Core SDK.

WORKDIR /
Here we "cd" to the root inside the container.

COPY . /HelloWorld
We copy the dir we are in into the directory /HelloWorld inside the conainer

WORKDIR /HelloWorld
We cd into HelloWorld  inside the container

RUN dotnet publish -c release -o /app
RUN tells docker we want to execute a terminal (bash/sh) command inside the container. So we execute dotnet publish inside the container. This means: Compile the code and move the output to /app

WORKDIR /app
We cd to app

ENTRYPOINT ["dotnet", "HelloWorld.dll"]
When docker run is invoked on our image, the command to run first is dotnet HelloWorld.dll. 