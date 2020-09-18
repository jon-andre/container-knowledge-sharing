using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Utilities
{
  public class DataAccess : IDataAccess
  {
    ILogger _logger;
    public DataAccess(ILogger logger)
    {
      _logger = logger;
    }

    public string LoadData()
    {
      var cs = "Host=localhost;Username=postgres;Password=password;Database=postgres";

      var con = new NpgsqlConnection(cs);
      con.Open();

      var sql = "SELECT valuea FROM mytable";

      var cmd = new NpgsqlCommand(sql, con);

      var fromDatabase = cmd.ExecuteScalar().ToString();
      con.Close();
      _logger.Log("Reading data from database.");
      return fromDatabase;
    }

    public void SaveData(string input)
    {
      var cs = "Host=localhost;Username=postgres;Password=password;Database=postgres";

      var con = new NpgsqlConnection(cs);
      con.Open();

      var sql = $"INSERT INTO mytable(valuea) VALUES('{ input }')";

      var cmd = new NpgsqlCommand(sql, con);

      cmd.ExecuteScalar();
      con.Close();

      _logger.Log("Saving data to database");
    }
  }
}
