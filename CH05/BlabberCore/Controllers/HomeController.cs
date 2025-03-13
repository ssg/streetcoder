using Blabber.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Blabber.Controllers;

public class HomeController(BlabStorage storage) : Controller
{
    private static readonly HomepageModel defaultHomepageModel = new()
    {
        Blabs = [],
        Form = new BlabForm(),
    };

    public ActionResult Index()
    {
        var model = defaultHomepageModel;
        model.Blabs = storage.GetAllBlabs();
        return View(model);
    }

    public ActionResult About()
    {
        ViewBag.Message = "Your application description page.";
        return View();
    }

    public ActionResult Contact()
    {
        ViewBag.Message = "Your contact page.";
        return View();
    }
}