using Autofac;
using System;

namespace ConsoleUI
{
  class Program
  {
    /* Make sure these are running. Should have been automatically executed by docker-compose
     * Note that this is for PowerShell and not cmd. Should be posssible to rewrite for cmd
     * 
     * docker run -p 5432:5432 --rm -e POSTGRES_PASSWORD=password -d postgres
     * docker run -ti --rm -v $ENV:UserProfile/source/repos/container-knowledge-sharing/HelloCompose/DemoLibrary/db_scripts:/flyway/sql flyway/flyway -url=jdbc:postgresql://host.docker.internal/ -schemas=postgres -user=postgres -password=password migrate
     */ 
    static void Main(string[] args)
    {
      /* Docker-compose is not too intelligent when it comes to knowing if
       * it is safe to proceed with the launching of containers. This means
       * you risk your application connecting to a DB before the migration
       * is completed! 
       */
      System.Threading.Thread.Sleep(5000);
      var container = ContainerConfig.Configure();

      using (var scope = container.BeginLifetimeScope())
      {
        var app = scope.Resolve<IApplication>();
        app.Run();
      }

      Console.ReadLine();
    }
  }
}
