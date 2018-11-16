using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Alva.ArTextBook.Features.Kernel
{
    public class UserController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        

        [Route("/Admin/User/Settings")]
        public IActionResult Settings()
        {
            return null;
        }
    }
}