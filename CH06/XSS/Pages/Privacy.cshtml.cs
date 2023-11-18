using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FoobleXSS.Pages;

public class PrivacyModel(ILogger<PrivacyModel> logger) : PageModel
{
    public void OnGet()
    {
        logger.LogDebug("GET request received");
    }
}