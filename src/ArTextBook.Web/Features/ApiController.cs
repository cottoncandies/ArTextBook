using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scietec.Combine.AspNetCore;

namespace Alva.ArTextBook.Features
{

    //[Route("ApiV1/[action]")]
    public class ApiController : BaseController
    {
        public ActionResult Ping()
        {
            return null;
        }
    }
}