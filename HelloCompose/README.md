# Introduction to Docker-Compose

One way of making life easier for devs is if we give them access to pretend DBs and other infrastructure that is relevant for their code. Then the devs can test their software safely in a realistic environment. 

All nice in theory, but it hasn't always been easy to implement in practice. DBs are really not systems you want on your local machine, as they can be a bit heavy on resources but also having local DBs can sometimes get in the way when we try to work on a DB in prod or in a common test environment. tnsnames.ora cough

However with Docker and containers, this is no longer a way of working that is just nice in theory! It is also nice in practice.

For instance you can fire up postgres in a cotainer with a command like:
docker run -p 5432:5432 --rm -e POSTGRES_PASSWORD=myPassword -d postgres

And if you are making use of a database versoning tool like Liquibase or Flyway, you can get a pretend database in no time!

docker run -ti --rm -v $ENV:UserProfile/source/repos/container-knowledge-sharing/HelloCompose/DemoApplication/DemoLibrary/db_scripts:/flyway/sql flyway/flyway -url=jdbc:postgresql://host.docker.internal/ -user=postgres -password=myPassword migrate

Note that this last command won't work if you don't have my exact repo structure. Also you might see a PowerShell variable in there, so running the command in cmd or shell won't work.

If you have a lot of moving parts in your infrastructure, this can both get time consuming and confusing! To be honest I even find this simple example a bit confusing because of the long terminal lines and I am the one who wrote the commands! Luckily, Docker provides us with a tool that takes care of this automatically. 

What we will do is to describe that we want to:

1 - Launch postgres
2 - Launch flyway and apply some SQL scripts
3 - Launch our container

These steps we will describe in the yaml file. /DemoApplication/docker-compose.yaml and Docker Compose is also the name of the tool we are now using. When this is up and running not only are you running your app and database as containers, but you have also taken the first step towards Infrastructure as Code! As the docker-compose.yaml basically is a small example of IaC.

Some nice commands to have ready:

To start the deployments, this should be launched from HelloCompose
docker-compose up

To remove the containers started by Docker Compose
docker-compose rm -fs

To do a rebuild of your container without using the Docker cache, you might have to do this to make sure you are actually running the current version of your container.
docker-compose build --no-cache

So a short notice at the end. I am not sure if this project has the optimal structure as this is pretty new stuff to me. Also after some reflection I removed the connection between docker-compose and Visual Studio. It is possible to launch docker-compose from VS, but I thought it created a lot of mess. A even more controversial opinion I have, is that I don't think your docker-compose really should be used on the code you are developing. To me it seems more natural to use docker-compose as a way to get infrastructure up and running, and when that is running you launch your container from VS. This is a subjective opinion though so I don't in any means say that everyone should work like me. 