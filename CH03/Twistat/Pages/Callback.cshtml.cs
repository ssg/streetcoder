using CoreTweet;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Twistat.Pages;

public class CallbackModel : PageModel
{
    public required IEnumerable<string> Nicks { get; set; }

    public void OnGet()
    {
        // https://localhost:44304/Callback?oauth_token=XhaguQAAAAABFEzEAAABcqR3JuQ&oauth_verifier=focVY8eYIvceblH3rNtPRNrEOtOUP0Pv
        var session = TempData["session"] as OAuth.OAuthSession;
        session.GetTokens(Request.Query["oauth_verifier"].First());
        var tokens = new Tokens()
        {
        };
        Nicks = tokens.Followers.EnumerateList(EnumerateMode.Next)
          .Select(e => e.Name);
    }
}