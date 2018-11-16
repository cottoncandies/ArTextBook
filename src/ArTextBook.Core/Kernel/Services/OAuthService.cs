using Scietec.Combine.Data;
using Scietec.Combine.Encode;
using Scietec.Combine;
using Scietec.Combine.Inject;
using System;
using System.Collections.Generic;
using System.Text;
using Scietec.Combine.Security;
using Alva.ArTextBook.Types;
using Alva.ArTextBook.Kernel.Workers;
using Alva.ArTextBook.Kernel.Tdm;
using Alva.ArTextBook.Kernel.Types;
using Alva.ArTextBook.Web;

namespace Alva.ArTextBook.Kernel.Services
{
    [Repository]
    public class OAuthService : ServiceBase
    {
        [Autowired]
        OAuthWorker oauthWorker = null;
        [Autowired]
        UserWorker userWorker = null;
        [Autowired]
        RoleWorker roleWorker = null;
        
        public OAuthTdm FindByOpenId(OAuthKind kind, string openId)
        {
            return DbSessionManager.Execute<OAuthTdm>((IDbSession sess) =>
            {
                return oauthWorker.FindByOpenId(sess, kind, openId);
            });
        }

        public void Save(OAuthTdm tdm)
        {
            DbSessionManager.ExecuteWithTrans<int>((IDbSession sess) =>
            {

                UserTdm user = new UserTdm();
                user.Id = sess.GetNextSequence("sys_user__id__seq");
                user.UserName = "?" + user.Id.ToString();
                user.NickName = String.IsNullOrEmpty(tdm.NickName)? user.UserName: tdm.NickName;
                user.Password = "123456".MD5();
                // userId.Avatar = "";
                user.Gender = tdm.Gender;
                userWorker.Save(sess,user);

                tdm.Id = sess.GetNextSequence("sys_oauth__id__seq");
                tdm.UserId = user.Id;
                oauthWorker.Save(sess, tdm);

                roleWorker.AddToRole(sess,user.Id, WebApp.UsersRoleId);
                return 0;
            });
        }

        public void Update(OAuthTdm tdm)
        {
            DbSessionManager.ExecuteWithTrans<int>((IDbSession sess) =>
            {
                return oauthWorker.Update(sess, tdm);                
            });
        }
    }
}
