using Domiki.Web.Business.Core;
using Domiki.Web.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Domiki.Web
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // IMessageWriter is injected into InvokeAsync
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BusinessException ex)
            {
                var jsonString = JsonConvert.SerializeObject(
                    new Response<string>(ex.Message) { Type = ResponseType.ErrorMessage }, 
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                await httpContext.Response.WriteAsync(jsonString);
            }
        }
    }
}
