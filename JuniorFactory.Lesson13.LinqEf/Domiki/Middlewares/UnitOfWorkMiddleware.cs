using Domiki.Web.Data;

namespace Domiki.Web
{
    public class UnitOfWorkMiddleware
    {
        private readonly RequestDelegate _next;

        public UnitOfWorkMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // IMessageWriter is injected into InvokeAsync
        public async Task InvokeAsync(HttpContext httpContext, UnitOfWork uow)
        {
            await _next(httpContext);
            uow.Commit();
        }
    }
}
