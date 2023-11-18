using CoreTweet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Twistat.Pages;

public class LoginModel(IConfiguration configuration) : PageModel
{
    public IActionResult OnGet()
    {
        string consumerKey = configuration["Twitter:ConsumerKey"]!;
        string consumerSecret = configuration["Twitter:ConsumerSecret"]!;
        var session = OAuth.Authorize(consumerKey, consumerSecret,
          oauthCallback: $"{Request.Scheme}://{Request.Host}/Callback");
        TempData["session"] = session;
        return Redirect(session.AuthorizeUri.AbsoluteUri);
    }
}