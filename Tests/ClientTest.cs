using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon.Objects
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact] //1
    public void Test_ClientEqualityOveride()
    {
      //Arrange
      Client firstClient = new Client("David");
      Client secondClient = new Client("David");

      //Act
      //Assert
      Assert.Equal(firstClient, secondClient);
    }


/////// Tear Down/////////////
    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  } //Class Closer
} // Namespace Closer
