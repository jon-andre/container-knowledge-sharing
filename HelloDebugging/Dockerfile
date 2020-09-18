FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine
WORKDIR /
COPY . /HelloDebugging
WORKDIR /HelloDebugging
RUN dotnet publish -c release -o /app
WORKDIR /

# So here we do something different from the HelloWorld example!
# Instead of setting the entrypoint (the command your container
# executes when you do a "docker run ... ) to the dotnet app you've
# compiled, we set it to be bash/sh/cmd/ps. This way we get to explore
# the container almost like it is a VM.
ENTRYPOINT ["/bin/sh"]