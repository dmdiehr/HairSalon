using System.Collections.Generic;
using System;

namespace HairSalon.Objects
{
  public class Stylist
  {
    private int _id;
    private string _name;

    public Stylist(string name, int id=0)
    {
      _name = name;
      _id = id;
    }
    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = this.GetId() == newStylist.GetId();
        bool nameEquality = this.GetName() == newStylist.GetName();
        return (idEquality && nameEquality);
      }

    // public method()
    // {
    //
    // }
  }
}
