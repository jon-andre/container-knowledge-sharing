using DemoLibrary.Utilities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
  public class BusinessLogic : IBusinessLogic
  {
    ILogger _logger;
    IDataAccess _dataAccess;

    public BusinessLogic(ILogger logger, IDataAccess dataAccess)
    {
      _logger = logger;
      _dataAccess = dataAccess;
    }

    public void ProcessData()
    {
      _logger.Log("Creating greeting.");
      var greeting = "Hello, " + _dataAccess.LoadData() + "!";
      _logger.Log("Greeting: " + greeting);
      _logger.Log("Greeting creation complete");
      _dataAccess.SaveData(greeting);
    }
  }
}