using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Http;

namespace FastFitProject.Models
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
    /*    protected override bool AuthorizeCore(HttpContext.User user)
        {
            // Generally authenticated to the site
            if (!DbContext.User.Identity.IsAuthenticated)
            {
                return false;
            }

            return true;
        }
*/
    }
}
