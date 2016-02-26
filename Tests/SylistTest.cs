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
/////// Tear Down/////////////
    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  } //Class Closer
} // Namespace Closer
