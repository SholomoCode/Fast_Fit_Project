using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Http;

namespace FastFitProject.Models
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
     /*   protected override bool AuthorizeCore(DbContext.Members user)
        {
            // Generally authenticated to the site
            if (!DbContext.Members.Identity.IsAuthenticated)
            {
                return false;
            }

            return true;
        }*/

    }
}
