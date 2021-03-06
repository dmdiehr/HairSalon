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
    [Fact]
    public void Test_ClientDelete()
    {
      //Arrange
      Client dummyClient1 = new Client("David");
      dummyClient1.Save();
      Client dummyClient2 = new Client("Max");
      dummyClient2.Save();

      List<Client> beforeList = Client.GetAll();

      //Act
      dummyClient1.Delete();

      //Arrange Again
      List<Client> afterList = Client.GetAll();
      List<Client> beforeCompareList = new List<Client> {dummyClient1, dummyClient2};
      List<Client> afterCompareList = new List<Client> {dummyClient2};

      //Assert
      Assert.Equal(beforeList, beforeCompareList);
      Assert.Equal(afterList, afterCompareList);
    }
    [Fact]
    public void Find_ClientInDb()
    {
      //Arrange
      Client testClient = new Client("David");
      testClient.Save();

      //Act
      Client foundClient = Client.Find(testClient.GetId());

      //Assert
      Assert.Equal(testClient, foundClient);
    }
    [Fact]
    public void Test_Update()
    {
      //Arrange
      Stylist dummyStylist1 = new Stylist("Jessica");
      Stylist dummyStylist2 = new Stylist("Melissa");
      dummyStylist1.Save();
      dummyStylist2.Save();
      Client dummyClient = new Client("Dave", dummyStylist1.GetId());
      dummyClient.Save();

      //Act
      dummyClient.Update("David", dummyStylist2.GetId());
          //Assert
      Assert.Equal(dummyClient.GetName(), "David");
      Assert.Equal(dummyClient.GetStylistId(), dummyStylist2.GetId());
    }
/////// Tear Down/////////////
    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  } //Class Closer
} // Namespace Closer
