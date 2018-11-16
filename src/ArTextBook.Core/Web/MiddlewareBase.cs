using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alva.ArTextBook.Web
{
    public class MiddlewareBase
    {
        protected readonly RequestDelegate _next;


        public MiddlewareBase(RequestDelegate next)
        {
            _next = next;
        }

        public void SendApi401(HttpContext context)
        {
            var r = context.Response;
            r.StatusCode = 401;
            StringBuilder sb = new StringBuilder();
            sb.Append("{code:-1,message:'Unauthorized(未授权)!'}");
            byte[] bs = Encoding.UTF8.GetBytes(sb.ToString());
            r.ContentLength = bs.Length;
            r.Body.Write(bs, 0, bs.Length);
        }

        public void SendWebPage401(HttpContext context)
        {
            var r = context.Response;
            r.StatusCode = 401;
            StringBuilder sb = new StringBuilder();
            sb.Append("<html><head><title>401 Unauthorized!</title>");
            sb.Append("<meta charset=\"UTF-8\">");
            sb.Append("<meta name=\"renderer\" content=\"webkit|ie-comp|ie-stand\">");
            sb.Append("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge,chrome=1\">");
            sb.Append("</head><body><h1>Unauthorized(未授权)!</h1></body></html>");
            byte[] bs = Encoding.UTF8.GetBytes(sb.ToString());
            r.ContentLength = bs.Length;
            r.Body.Write(bs, 0, bs.Length);
        }
    }
}
