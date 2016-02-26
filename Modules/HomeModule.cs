using Nancy;
using HairSalon.Objects;
using System.Collections.Generic;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {

      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Post["/output"] = _ =>
      {
        string result = "";
        return View["output.cshtml", result];
      };
    }
  }
}
