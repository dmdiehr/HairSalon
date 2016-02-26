using System.Collections.Generic;
using Xunit;
namespace HairSalon.Objects
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact] //1
    public void method_test()
    {
      //Arrange

      //Act

      //Assert
    }
    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  }
}
