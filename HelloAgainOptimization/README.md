# Optimization

So here is another tip on how to optimize your containers. But this is more related to .NET Core than Docker. Instead of building our code for a bunch of platforms we only build it for linux-musl-x64. This means our code won't be multiplatform, but who cares? We know that our code only will run on Alpine anyway! We also tell dotnet to remove unused dependencies.

As we saw from the previous Dockerfile our container doesn't run! The reason is simple, our Alpine base image is so stripped down it doesn't have the libraries that .NET Core requires. The fix is simple, we just have to install the .NET Core dependencies