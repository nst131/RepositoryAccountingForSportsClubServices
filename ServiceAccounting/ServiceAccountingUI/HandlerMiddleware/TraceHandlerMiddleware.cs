using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ServiceAccountingUI.HandlerMiddleware
{
    public class TraceHandlerMiddleware
    {
        private const string TraceHeaderName = "X-Trace_Id";

        private readonly RequestDelegate _next;

        public TraceHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var traceId = context.Request.Headers.ContainsKey(TraceHeaderName)
                ? context.Request.Headers[TraceHeaderName].First()
                : Guid.NewGuid().ToString();

            await _next(context);

            context.Response.Headers.Add(TraceHeaderName, traceId);
        }
    }
}
