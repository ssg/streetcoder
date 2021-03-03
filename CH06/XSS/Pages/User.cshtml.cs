using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace FoobleXSS.Pages
{
    public class UserModel : PageModel
    {
        public IHtmlContent? Username { get; set; }

        public void OnGet(string username)
        {
            bool isActive = isUserActive(username);
            var content = new HtmlContentBuilder();
            if (isActive)
            {
                content.AppendFormat("<a href='/user/{0}'>", username);
            }
            content.Append(username);
            if (isActive)
            {
                content.AppendHtml("</a>");
            }
            Username = content;
        }

        private bool isUserActive(string _)
        {
            return false;
        }

        private Range getRowRange(int pageIndex, int pageSize)
        {
            int startRow = (pageIndex - 1) * pageSize;
            int endRow = startRow + pageSize;
            return new Range(startRow, endRow);
        }
    }
}