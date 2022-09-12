using CoreTweet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Twistat.Pages;

public class LoginModel : PageModel
{
    private readonly IConfiguration config;

    public LoginModel(IConfiguration configuration)
    {
        this.config = configuration;
    }

    public IActionResult OnGet()
    {
        string consumerKey = config["Twitter:ConsumerKey"];
        string consumerSecret = config["Twitter:ConsumerSecret"];
        var session = OAuth.Authorize(consumerKey, consumerSecret,
          oauthCallback: $"{Request.Scheme}://{Request.Host}/Callback");
        TempData["session"] = session;
        return Redirect(session.AuthorizeUri.AbsoluteUri);
    }
}