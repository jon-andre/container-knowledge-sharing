# Introduction to Docker-Compose

One way of making life easier for devs is if we give them access to pretend DBs and other infrastructure that is relevant for their code. Then the devs can test their software safely in a realistic environment. 

All nice in theory, but it hasn't always been easy to implement in practice. DBs are really not systems you want on your local machine, as they can be a bit heavy on resources but also having local DBs can sometimes get in the way when we try to work on a DB in prod or in a common test environment. tnsnames.ora cough

However with Docker and containers, this is no longer a way of working that is just nice in theory! It is also nice in practice.

For instance you can fire up postgres in a cotainer:
docker run -p 5432:5432 --rm -e POSTGRES_PASSWORD=password -d postgres

And if you are making use of a database versoning tool like Liquibase or Flyway, you can get a pretend database in no time!

docker run -ti --rm -v C:/Users/JBrurbe/source/repos/container-knowledge-sharing/HelloCompose/DemoLibrary/db_scripts:/flyway/sql flyway/flyway -url=jdbc:postgresql://host.docker.internal/ -schemas=postgres -user=postgres -password=password migrate

However these things can be tiring (and confusing) to do ourselves if we have a lot of moving parts, and this is what Docker-Compose does for us.

So what we will basically do is to tell Docker:

1 - Launch postgres
2 - Launch flyway and apply migration
3 - Launch our container