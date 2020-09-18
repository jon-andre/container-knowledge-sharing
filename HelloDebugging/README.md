# Debugging

So one of the tricky parts about Docker an containers is that you mentally have to visualize the container. Luckily there's a small trick we can do to enter the container and have a look around. We do this by switching the entrypoint of our container to /bin/bash