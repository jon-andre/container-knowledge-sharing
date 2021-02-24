# Optimization

Note: This project will give you a Dockerfile that compiles to an image, but it will fail to run. This is explained in HelloAgainOptimization.

So the following way of building our .NET Core app is not very effective!

Building our app this way leaves us with a container at the whopping size of 400MB! Kinda excessive for a simple HelloWorld app right?

The observant reader might have seen that we download the whole .NET Core SDK as our base image. This is really smart for building our app, but we don't need really need the whole SDK just to run our code when it is finally built. So instead what we're going to do, is to build our app in a container that has the whole SDK installed and then pass the compiled program to a minimal container! 

This is really simple as Docker has a concept called multi-staged building. You can see that multi-staged building is in use if you see two FROM commands in the same Dockerfile. Basically what that is, is that you create and build your container as you normally would, then with the 2nd FROM command you "delete" that container and create a new one. Since all this is done in the same Dockerfile, you still have access to the contents of the old container. So then you can just tell Docker to copy the compiled files from the old container, over to the new one

COPY --from=old-container /app /app

As you see, this is the same COPY command you use to move files from your system over to a container, but we specify that we want to move files from a named container instead.