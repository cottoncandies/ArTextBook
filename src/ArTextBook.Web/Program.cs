using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Alva.ArTextBook.Web;

namespace Alva.ArTextBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApp.Init(typeof(Program));          

            BuildWebHost(args).Run();

            WebApp.Destroy();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
