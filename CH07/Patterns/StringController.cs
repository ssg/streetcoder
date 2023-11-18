using Microsoft.AspNetCore.Mvc;

namespace Patterns;
class StringController : Controller
{
    public IActionResult Bozo()
    {
        HttpContext.Items["Bozo"] = true;
        return View();
    }

    public IActionResult IsBozo()
    {
        if ((bool?)HttpContext.Items["Bozo"] == true)
        {
            return View("Bozo");
        }
        return View("NotBozo");
    }
}
