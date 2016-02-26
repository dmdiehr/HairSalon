using System.Collections.Generic;
using System;

namespace HairSalon.Objects
{
  public class Client
  {
    private int _id;
    private string _name;
    private int _stylistId;

    public Client(string name,int stylistId, int id=0)
    {
      _name = name;
      _stylistId = stylistId;
      _id = id;
    }


    // public method()
    // {
    //
    // }
  }
}
