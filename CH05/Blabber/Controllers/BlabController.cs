using Blabber.Models;
using System;
using System.Web.Mvc;

namespace Blabber.Controllers
{
    public class BlabController : Controller
    {
        private readonly BlabStorage _storage;

        public BlabController(BlabStorage storage)
        {
            _storage = storage;
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
            _storage.Add(blab);
            return home();
        }
    }
}