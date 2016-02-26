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
    [Fact] //1
    public void Test_StylistEqualityOveride()
    {
      //Arrange
      Client firstStylist = new Client("Jessica");
      Client secondStylist = new Client("Jessica");

      //Act
      //Assert
      Assert.Equal(firstStylist, secondStylist);
    }

/////// Tear Down/////////////
    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  } //Class Closer
} // Namespace Closer
