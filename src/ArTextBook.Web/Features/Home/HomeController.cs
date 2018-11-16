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

namespace Alva.ArTextBook.Features.Home
{
    public class HomeController : BaseController
    {
        [Autowired]
        ModuleService moduleService = null;

        public HomeController()
        {
            BeanManager.Autowire(this);
        }

        public IActionResult Index()
        {
            var sess = Request.GetCSession();
            if (null != sess.GetUser())
            {
                return Redirect("/Home/Main");
            }
            else
            {
                return Redirect("/Home/Login");
            }
        }

        //[Route("/Login")]
        public IActionResult Login()
        {
            var sess = Request.GetCSession();
            if (null != sess.GetUser())
            {
                return Redirect("/Home/Main");
            }
            return View();
        }

        // [Route("/Logout")]
        public IActionResult Logout()
        {
            var sess = Request.GetCSession();
            sess.Exit();
            return Redirect("/Home/Login");
        }

        // [Route("/Main")]
        public IActionResult Main()
        {
            var sess = Request.GetCSession();
            var su = sess.GetUser();
            //List<ModuleVdm> menus = su.UserMenus;
            //if (null == menus)
            //{
            //    menus = moduleService.GetUserModule(su.Id).Menus;
            //    su.UserMenus = menus;
            //    sess.SetUser(su);
            //}

            List<ModuleVdm> menus = moduleService.GetUserPrivileges(su.Id).Menus;            
            ViewData["MENU"] = ModuleListToMenu(menus);
            return View();
        }

        private string ModuleListToMenu(List<ModuleVdm> menus)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul id=\"nav\">");
            foreach (var mmi in menus)
            {
                if (mmi.Kind == ModuleKind.Module)
                {
                    MakeMenuItem(mmi, sb);
                }
                else if (mmi.Kind == ModuleKind.Group)
                {
                    MakeMenuGroup(mmi, sb);
                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        private void MakeMenuGroup(ModuleVdm mmi, StringBuilder sb)
        {
            sb.Append("<li><a href=\"javascript:;\">")
              .Append("<i class=\"").Append(mmi.Icon).Append("\">&#xe70b;</i>")
              .Append("<cite>").Append(mmi.Caption).Append("</cite>")
              .Append("<i class=\"iconfont nav_right\">&#xe697;</i>")
              .Append("</a>")
              .Append("<ul class=\"sub-menu\">");
            foreach (var smi in mmi.Childs)
            {
                if (smi.Kind == ModuleKind.Module)
                {
                    MakeMenuItem(smi, sb);
                }
                else if (smi.Kind == ModuleKind.Group)
                {
                    MakeMenuGroup(smi, sb);
                }
            }
            sb.Append("</ul></li>");
        }

        private void MakeMenuItem(ModuleVdm mmi, StringBuilder sb)
        {
            sb.Append("<li><a _href=\"").Append(mmi.Uri).Append("\">")
                .Append("<i class=\"").Append(mmi.Icon).Append("\">&#xe6a7;</i>")
                .Append("<cite>").Append(mmi.Caption).Append("</cite>")
                .Append("</a></li>");
        }

        //[Route("/About")]
        public IActionResult About()
        {
            return View();
        }

        // [Route("/Error")]
        public IActionResult Error()
        {
            return View(new ErrorVdm { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
