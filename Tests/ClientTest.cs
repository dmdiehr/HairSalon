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
    [Fact]
    public void Test_ClientEqualityOveride()
    {
      //Arrange
      Client firstClient = new Client("David");
      Client secondClient = new Client("David");

      //Act
      //Assert
      Assert.Equal(firstClient, secondClient);
    }
    [Fact]
    public void Test_ClientsEmptyAtFirst()
    {
      //Arrange, Act
      int result = Client.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_ClientSave()
    {
      //Arrange, Act
      Client newClient = new Client("David");
      newClient.Save();

      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{newClient};

      //Assert
      Assert.Equal(testList, result);
    }
/////// Tear Down/////////////
    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  } //Class Closer
} // Namespace Closer
