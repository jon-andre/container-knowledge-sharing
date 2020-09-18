# Debugging

So one of the tricky parts about Docker an containers is that you mentally have to visualize the container. Luckily there's a small trick we can do to enter the container and have a look around. We do this by switching the entrypoint of our container to /bin/bash or /bin/sh

When doing docker run with that as an entrypoint, it seems a bit like you have SSHed or used Putty to connect to a Linux machine. Use this as a tool to inspect the folder structures and contentes. For instance you can check that the 'dotnet publish' really published to the app folder at the root directory.