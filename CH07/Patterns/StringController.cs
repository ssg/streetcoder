using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns; 
class StringController: Controller {
public IActionResult Bozo() {
HttpContext.Items["Bozo"] = true;
return View();
}

public IActionResult IsBozo() {
if ((bool?)HttpContext.Items["Bozo"] == true) {
return View("Bozo");
}
  return View("NotBozo");
}
}
