using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Alva.ArTextBook.Features.Kernel
{
    //[Route("ApiV1/Role/[action]/{id?}")]
    public class RoleApiController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}