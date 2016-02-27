using Nancy;
using HairSalon.Objects;
using System.Collections.Generic;
using System;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {

      Get["/"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Post["/stylist/new"] = _ => {
      Stylist newStylist = new Stylist(Request.Form["stylist-add"]);
      newStylist.Save();
      List<Stylist> allStylists = Stylist.GetAll();
      return View["index.cshtml", allStylists];
      };
      Get["/stylists/{id}"]= parameters =>{
        Stylist selectedStylist = Stylist.Find(parameters.id);
        List<Client> clientList = selectedStylist.GetClients();
        Tuple<int, string, List<Client>> modelTuple = new Tuple<int, string, List<Client>> (selectedStylist.GetId(), selectedStylist.GetName(), clientList);
        return View["stylist.cshtml", modelTuple];
      };
      Post["/client/new"] = _ => {
        Client newClient = new Client(Request.Form["client-name"], Request.Form["client-stylistId"]);
        newClient.Save();
        string message = "Successfully added client";
        return View["success.cshtml", message];
      };
      Get["/client/delete/{id}"]= parameters =>{
        Client selectedClient = Client.Find(parameters.id);
        selectedClient.Delete();
        string message = "Successfully deleted client";
        return View["success.cshtml", message];
      };
      Get["/stylist/delete/{id}"]= parameters =>{
        Stylist selectedStylist = Stylist.Find(parameters.id);
        selectedStylist.Delete();
        string message = "Successfully deleted the stylist.";
        return View["success.cshtml", message];
      };
      Get["/stylist/edit/{id}"]= parameters =>{
        Stylist selectedStylist = Stylist.Find(parameters.id);

        return View["edit_stylist.cshtml", selectedStylist];
      };
      Get["/client/edit/{id}"]= parameters =>{
        Client selectedClient = Client.Find(parameters.id);
        List<Stylist> stylistList = Stylist.GetAll();
        Tuple<Client, List<Stylist>> modelTuple = new Tuple<Client, List<Stylist>> (selectedClient, stylistList);

        return View["edit_client.cshtml", modelTuple];
      };

      Post["/edit_stylist/{id}"]= parameters => {
        Stylist newStylist = Stylist.Find(parameters.id);
        newStylist.Update(Request.Form["stylist-name"]);
        string message = "Successfully edited stylist.";
        return View["success.cshtml", message];
      };
      Post["/edit_client/{id}"]= parameters => {
        Client newClient = Client.Find(parameters.id);
        newClient.Update(Request.Form["client-name"], Request.Form["client-stylistId"]);
        string message = "Successfully edited client.";
        return View["success.cshtml", message];
      };


    }
  }
}
