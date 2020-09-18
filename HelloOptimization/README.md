# Optimization

So the following way of building our .NET Core app is not very effective:

RUN dotnet publish -c release -o /app
Building our app this way leaves us with a container at the whopping size of 400MB! Kinda excessive for a simple HelloWorld app right?

The observant reader might have seen that we download the whole .NET Core SDK as our base image. This is really smart for building our app, but we don't need the SDK to run our code when it is finally built. So instead what we're going to do, is to build our app in a container that has the whole SDK installed and then pass the compiled program to a container that only has the necessary runtimes/libraries installed.