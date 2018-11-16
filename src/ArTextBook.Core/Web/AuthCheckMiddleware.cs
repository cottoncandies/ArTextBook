using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alva.ArTextBook.Types;
using Alva.ArTextBook.Utils;
using Alva.ArTextBook.Kernel.Vdm;

namespace Alva.ArTextBook.Web
{
    public class AuthCheckMiddleware : MiddlewareBase
    {
        private readonly ILogger _logger;

        public AuthCheckMiddleware(RequestDelegate next,
            ILoggerFactory loggerFactory) : base(next)
        {
            _logger = loggerFactory.CreateLogger<AuthCheckMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            UriCompletionResult ucr = UriCompletion.Completion(context.Request.Path);
            context.SetCurrentUri(ucr.FullUrl);
            if (!context.Request.AuthCheck(ucr.FullUrl))
            {
                if (ucr.IsApi) //API拒绝
                {
                    SendApi401(context);
                }
                else //WEB Page拒绝
                {
                    SendWebPage401(context);
                }
            }
            else
            {
                await _next.Invoke(context);
            }            
        }
    }
}
