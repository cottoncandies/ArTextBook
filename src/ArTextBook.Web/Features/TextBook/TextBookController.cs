using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Alva.ArTextBook.Kernel.Vdm;
using Alva.ArTextBook.Utils;
using Microsoft.AspNetCore.Http;
using Alva.ArTextBook.Types;
using Scietec.Combine.Inject;
using System.Text;
using Alva.ArTextBook.Kernel.Services;
using Alva.ArTextBook.Kernel.Types;
using Alva.ArTextBook.Web;
using Scietec.Combine.AspNetCore;

namespace Alva.ArTextBook.Features.TextBook
{
    public class TextBookController : BaseController
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}
