using Blabber.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Blabber.Controllers;

public class BlabController(BlabStorage storage) : Controller
{
    private RedirectToActionResult home()
    {
        return RedirectToAction("Index", "Home");
    }

    public ActionResult Post(BlabForm form)
    {
        if (!ModelState.IsValid)
        {
            return home();
        }

        var blab = new Blab(form.Content!, DateTimeOffset.Now);
        storage.Add(blab);
        return home();
    }
}