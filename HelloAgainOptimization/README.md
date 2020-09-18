# Optimization

Before continuing with solving the issue from HelloOptimization, heres another tip on how to optimize your container's storage requirements. This is more related to .NET Core than Docker though.

So .NET Core is multiplatform, so when we are compiling our code we end up with a bunch of runtimes. As we know that our code only runs on Alpine Linux (the linux-musl-x64 runtime), do we really need all the other runtime? No. we don't! So lets take a quick look at what parameters we can use to slim down our container!

Specify what runtime you're going to use. The most common other options are win-x64 and linux-x64
-r linux-musl-x64
Make your application self-contained. You will have a larger application but less dependencies. Not sure if this is beneficial in terms of size
--self-contained true
Removes unused and unecessary DLLs
-p:PublishTrimmed=true
Compiles your app down to one file. Not possible if your project has a requirment to another project.
-p:PublishSingleFile=true
Makes your file slightly bigger, but it will be faster to launch it, from what I gathered
-p:PublishReadyToRun=true

With these in place we manage to shrink our container from 450MB to 45MB. However there might still be optimizations to be done here. Speaking of optimization, Microsoft provides us images where the runtime dependencies are taken care of.

The error from our HelloOptimization is also related to optimization. In that example we just optimized too much as we used a vanilla Alpine Linux base. Vanilla Alpine lacks a lot of the libraries we need to run our code, but once we have them in place as we do in this example, the code will run as expected.