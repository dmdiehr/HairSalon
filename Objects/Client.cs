using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon.Objects
{
  public class Client
  {
    private int _id;
    private string _name;
    private int _stylistId;

////////Standard Methods//////////////

    public Client(string name,int stylistId=0, int id=0)
    {
      _name = name;
      _stylistId = stylistId;
      _id = id;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public int GetStylistId()
    {
      return _stylistId;
    }
    public void SetStylistId(int newStylist)
    {
      _stylistId = newStylist;
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
    }

////////////Tested Methods//////////////////////

    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = this.GetId() == newClient.GetId();
        bool nameEquality = this.GetName() == newClient.GetName();
        bool stylistIdEquality = this.GetStylistId() == newClient.GetStylistId();
        return (idEquality && nameEquality && stylistIdEquality);
      }
    }
  } //Class Closer
} // Namespace Closer
