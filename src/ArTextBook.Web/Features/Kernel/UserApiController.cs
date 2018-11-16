using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scietec.Combine.AspNetCore;
using Alva.ArTextBook.Types;
using Alva.ArTextBook.Utils;
using Scietec.Combine.Inject;
using Alva.ArTextBook.Kernel.Vdm;
using Alva.ArTextBook.Kernel.Tdm;
using Alva.ArTextBook.Kernel.Services;
using Alva.ArTextBook.Web;
using Newtonsoft.Json;

namespace Alva.ArTextBook.Features.Kernel
{
    //[Route("Api/V1/User/[action]/{id?}")]
    public class UserApiController : BaseController
    {
        [Autowired]
        UserService userService = null;
        [Autowired]
        ModuleService moduleService = null;

        public UserApiController()
        {
            BeanManager.Autowire(this);
        }

        public ActionResult Login()
        {
            var userInfo = Request.ReadJsonToObject<LoginInfoVdm>();
            var sess = Request.GetCSession();
            var u = userService.Login(userInfo.Username, userInfo.Password);
            if (!u.Ok)
            {
                return ApiFailed<SessionalUser>(u.Message);                
            }
            SessionalUser su = new SessionalUser(u.Data);
            su.AuthMap = moduleService.GetUserAuthMap(su.Id);
            //su.UserMenus = userModules.Menus;
            sess.SetUser(su);
            return ToSessionalUser(su);
        }

        private ActionResult ToSessionalUser(SessionalUser su)
        {
            var u = new {
                id = su.Id,
                username = su.UserName,
                nickname = su.NickName,
                gender = su.Gender,
                email = su.Email,
                mobile = su.Mobile,
                slogan = su.Slogan,
                avatar = su.Avatar
            };
            return ApiSuccessful<dynamic>(u);
            //string s = JsonConvert.SerializeObject(u);
            //return JsonText("{code:0,message:\"Successful\",data:" + s + "}");
        }

        public IActionResult FindUser()
        {
            return View();
        }
    }
}