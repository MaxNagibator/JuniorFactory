using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JuniorFactory.Lesson8.Middlewares
{
    public enum Permissions
    {
        Admin = 1,
        User = 2,
    }

    public class AuthFilter : ActionFilterAttribute
    {
        private Permissions _permission;

        public AuthFilter(Permissions permission)
        {
            _permission = permission;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Permissions? permission = null;
            if (context.HttpContext.Request.Headers.Keys.Contains("auth"))
            {
                var authkey = context.HttpContext.Request.Headers["auth"];
                if (authkey == "secret123token")
                {
                    permission = Permissions.Admin;
                }
                if (authkey == "plodder")
                {
                    permission = Permissions.User;
                }
            }
            if (permission == null)
            {
                throw new Exception("auth troubles");
            }

            if (permission == Permissions.User && _permission == Permissions.Admin)
            {
                throw new Exception("you are not admin!");
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
