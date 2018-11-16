using Alva.ArTextBook.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Scietec.Combine;
using Scietec.Combine.Security;
using Scietec.Combine.Inject;
using Scietec.Combine.Data;
using Alva.ArTextBook.Kernel.Tdm;
using Alva.ArTextBook.Kernel.Types;
using Alva.ArTextBook.Kernel.Workers;
using Alva.ArTextBook.Web;

namespace Alva.ArTextBook.Kernel.Services
{
    [Repository]
    public class UserService : ServiceBase
    {
        [Autowired]
        UserWorker userWorker = null;
        [Autowired]
        RoleWorker roleWorker = null;

        public UserTdm FindById(long id)
        {
            return DbSessionManager.Execute<UserTdm>((IDbSession sess) => {
                return userWorker.FindById(sess, id);
            });
        }

        public UserTdm FindByUsername(string uname)
        {
            return DbSessionManager.Execute<UserTdm>((IDbSession sess)=>{
                return userWorker.FindByUserName(sess,uname);
            });
        }

        public MethodResult<UserTdm> Login(string username, string password)
        {
            return DbSessionManager.Execute<MethodResult<UserTdm>>((IDbSession sess) => {
                UserTdm u = userWorker.FindByUserName(sess,username);
                if (null == u || String.IsNullOrEmpty(password))
                {
                    return MethodResult<UserTdm>.Failed("用户名或密码错误！");
                }

                if(u.Kind == UserKind.Virtual)
                {
                    return MethodResult<UserTdm>.Failed("账户不存在！");
                }

                if (u.RowState != RowState.Normal
                    || (u.Locked && u.TimeLocked > DateTime.Now))
                {
                    return MethodResult<UserTdm>.Failed("账户已经被锁定，请稍后再试！");
                }

                password = password.MD5();
                if (password == u.Password)
                {
                    userWorker.SetLoginSuccess(sess,u.Id);
                    return MethodResult<UserTdm>.Successful(u);
                }

                userWorker.SetLoginFailed(sess, u.Id, u.FailCount > WebApp.PasswordFailCount);               
                return MethodResult<UserTdm>.Failed("用户名或密码错误！");
            });           
        }

        public void Save(UserTdm user)
        {
            DbSessionManager.Execute<int>((IDbSession sess) => {
                userWorker.Save(sess, user);
                return 0;
            });
        }

        public void Save(UserTdm user, List<long> roleIds)
        {
            DbSessionManager.ExecuteWithTrans<int>((IDbSession sess) => {
                userWorker.Save(sess, user);
                foreach (var i in roleIds)
                {
                    roleWorker.AddToRole(sess, user.Id, i);
                }
                return 0;
            });
        }

        public void Update(UserTdm user)
        {
            DbSessionManager.Execute<int>((IDbSession sess) => {
                userWorker.Update(sess, user);
                return 0;
            });
        }
    }
}
