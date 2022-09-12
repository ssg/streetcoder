using Blabber.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Blabber.Controllers;

public class BlabController : Controller
{
    private readonly BlabStorage storage;

    public BlabController(BlabStorage storage)
    {
        this.storage = storage;
    }

    private ActionResult home()
    {
        return RedirectToAction("Index", "Home");
    }

    public ActionResult Post(BlabForm form)
    {
        if (!ModelState.IsValid)
        {
            return home();
        }

        var blab = new Blab(form.Content, DateTimeOffset.Now);
        storage.Add(blab);
        return home();
    }
}