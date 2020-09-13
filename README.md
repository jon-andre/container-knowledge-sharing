# Docker 101
Some simple .NET Core C# examples to illustrate how to use Docker.

## HelloWorld
A simple Dockerfile using the Alpine .NET Core SDK base image. Builds a simple image with a console application.

## HelloDebugging
The same setup as HelloWorld, but here we use /bin/sh as an entrypoint to show how you can explore and debug the running container.

## HelloOptimization
Introduces multi-stage builds and shows how we use them to make our images smaller. Also shows some of the challenges we face when trying to minimize our containers.

## HelloAgainOptimization
Shows how to fix the errors from HelloOptimization and also introduces a slightly more advanced 'dotnet publish' command that suits containers better than the vanilla 'dotnet publish' command.
