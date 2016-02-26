using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;


namespace HairSalon.Objects
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_StylistEqualityOveride()
    {
      //Arrange
      Stylist firstStylist = new Stylist("Jessica");
      Stylist secondStylist = new Stylist("Jessica");

      //Act
      //Assert
      Assert.Equal(firstStylist, secondStylist);
    }
    [Fact]
    public void Test_StylistsEmptyAtFirst()
    {
      //Arrange, Act
      int result = Stylist.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_StylistSave()
    {
      //Arrange, Act
      Stylist newStylist = new Stylist("Jessica");
      newStylist.Save();

      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{newStylist};

      //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_StylistDelete()
    {
      //Arrange
      Stylist dummyStylist1 = new Stylist("Jessica");
      dummyStylist1.Save();
      Stylist dummyStylist2 = new Stylist("Melissa");
      dummyStylist2.Save();

      List<Stylist> beforeList = Stylist.GetAll();

      //Act
      dummyStylist1.Delete();

      //Arrange Again
      List<Stylist> afterList = Stylist.GetAll();
      List<Stylist> beforeCompareList = new List<Stylist> {dummyStylist1, dummyStylist2};
      List<Stylist> afterCompareList = new List<Stylist> {dummyStylist2};

      //Assert
      Assert.Equal(beforeList, beforeCompareList);
      Assert.Equal(afterList, afterCompareList);
    }
    [Fact]
    public void Find_StylistInDb()
    {
      //Arrange
      Stylist testStylist = new Stylist("Jessica");
      testStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      //Assert
      Assert.Equal(testStylist, foundStylist);
    }
    [Fact]
    public void Test_StylistDelete_UpdatesClientStylistId()
    {
      //Arrange
      Stylist dummyStylist1 = new Stylist("Jessica");
      dummyStylist1.Save();
      int dummyStylist1Id = dummyStylist1.GetId();
      Stylist dummyStylist2 = new Stylist("Melissa");
      dummyStylist2.Save();
      int dummyStylist2Id = dummyStylist2.GetId();


      Client beforeClient1 = new Client("David", dummyStylist1Id);
      beforeClient1.Save();
      Client beforeClient2 = new Client("Max", dummyStylist2Id);
      beforeClient2.Save();

      //Act
      dummyStylist1.Delete();
      Client afterClient1 = Client.Find(beforeClient1.GetId());
      Client afterClient2 = Client.Find(beforeClient2.GetId());

      //Assert
      Assert.Equal(0, afterClient1.GetStylistId());
      Assert.Equal(dummyStylist2Id, afterClient2.GetStylistId());
    }
/////// Tear Down/////////////
    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  } //Class Closer
} // Namespace Closer
