namespace JuniorFactory.Lesson7
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            await _next(httpContext);
            //if (httpContext.Request.Headers.Keys.Contains("auth"))
            //{
            //    var authkey = httpContext.Request.Headers["auth"];
            //    if(authkey == "secret123token")
            //    {
            //        await _next(httpContext);
            //        return;
            //    }
            //}

            //await httpContext.Response.WriteAsync("auth troubles");
        }
    }
}
