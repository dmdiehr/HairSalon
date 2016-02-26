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
      Client firstStylist = new Client("Jessica");
      Client secondStylist = new Client("Jessica");

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

/////// Tear Down/////////////
    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  } //Class Closer
} // Namespace Closer
