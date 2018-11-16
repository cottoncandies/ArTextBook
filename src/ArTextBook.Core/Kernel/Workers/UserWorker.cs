using Alva.ArTextBook.Kernel.Tdm;
using Alva.ArTextBook.Types;
using Scietec.Combine.Data;
using Scietec.Combine.Inject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Alva.ArTextBook.Kernel.Types;
using Alva.ArTextBook.Kernel.Where;

namespace Alva.ArTextBook.Kernel.Workers
{
    [Repository]
    public class UserWorker : WorkerBase
    {
        #region SQL
        private const string SelectUser = @"
        select 
	        u.ng_id as Id,
	        u.sz_uname as UserName,
	        u.sz_nkname as NickName,
	        u.sz_pwd as Password,
	        u.sz_email as Email,
	        u.sz_mobile as Mobile,
            u.nt_kind as UserKind,
            u.nt_gender as Gender,
            u.sz_slogan as Slogan,
            u.sz_avatar as Avatar,
	        u.bn_locked as Locked,
	        u.ts_locked as TimeLocked,	
	        u.nt_fcnt as FailCount,	
	        u.nt_login_cnt as LoginCount,
	        u.ts_last_login as LastLogin,
	        u.nt_state as State,
	        u.ng_ctor_id as CreatorId,
	        uc.sz_uname as CreatorName,	
	        u.ng_uper_id as UpdaterId,
	        uu.sz_uname as UpdaterName,
	        u.ts_create as TimeCreate,
	        u.ts_update as TimeUpdate,
	        u.nt_r_state as RowState,
	        u.nt_r_ver as RowVersion
        from sys_user_t u left join sys_user_t uc on u.ng_ctor_id=uc.ng_id
	        left join sys_user_t uu on u.ng_uper_id=uu.ng_id
    ";
        #endregion

        public Pagable<UserTdm> Find(IDbSession sess, UserWhere where)
        {
            return null;
        }

        public UserTdm FindById(IDbSession sess, long id)
        {
            SqlSelect ss = new SqlSelect(sess);
            ss.Sql = SelectUser;
            ss.Where = "u.ng_id=@userId";
            ss.AddParam("@userId", id);
            return ss.ExecuteSingle<UserTdm>();
        }

        public UserTdm FindByUserName(IDbSession sess, string username)
        {
            SqlSelect ss = new SqlSelect(sess);
            ss.Sql = SelectUser;
            ss.Where = "u.sz_uname=@uname";
            ss.AddParam("@uname", username);
            return ss.ExecuteSingle<UserTdm>();
        }

        public UserTdm FindByMobile(IDbSession sess, string mobile)
        {
            SqlSelect ss = new SqlSelect(sess);
            ss.Sql = SelectUser;
            ss.Where = "u.sz_email=@sz_email";
            ss.AddParam("@sz_email", mobile);
            return ss.ExecuteSingle<UserTdm>();
        }

        public UserTdm FindByEmail(IDbSession sess, string email)
        {
            SqlSelect ss = new SqlSelect(sess);
            ss.Sql = SelectUser;
            ss.Where = "u.sz_mobile=@sz_mobile";
            ss.AddParam("@sz_mobile", email);
            return ss.ExecuteSingle<UserTdm>();
        }

        public void Save(IDbSession sess, UserTdm user)
        {
            if (user.Id == 0)
            {
                user.Id = sess.GetNextSequence("sys_user__id__seq");
            }

            SqlInsert ss = new SqlInsert(sess);
            ss.Sql = "sys_user_t";
            ss.Set("sz_uname", user.UserName)
               .Set("sz_nkname", user.NickName)
               .Set("sz_pwd", user.Password)
               .Set("sz_email", user.Email)
               .Set("sz_mobile", user.Mobile)
               .Set("nt_kind", (int)user.Kind)
               .Set("nt_gender", (int)user.Gender)
               .Set("sz_slogan", user.Slogan)
               .Set("sz_avatar", user.Avatar)
               .Set("ng_ctor_id", user.CreatorId)
               .Set("ng_uper_id", user.UpdaterId)
               .Set("ng_id", user.Id);
            ss.ExecuteNonQuery();
        }

        public void Update(IDbSession sess, UserTdm user)
        {
            var ss = new SqlUpdate(sess);
            ss.Sql = "sys_user_t";
            ss.Where = "ng_id=@ng_id";
            ss.Set("sz_uname", user.UserName)
               .Set("sz_nkname", user.NickName)
               .Set("sz_email", user.Email)
               .Set("sz_mobile", user.Mobile)
               .Set("nt_kind", (int)user.Kind)
               .Set("nt_gender", (int)user.Gender)
               .Set("sz_slogan", user.Slogan)
               .Set("sz_avatar", user.Avatar)
               .Set("ng_uper_id", user.UpdaterId)
               .AddParam("ng_id", user.Id);
            ss.ExecuteNonQuery();
        }

        public void SetLoginSuccess(IDbSession sess, long userId)
        {
            SqlUpdate su = new SqlUpdate(sess);
            su.Sql = "sys_user_t";
            su.Set("nt_fcnt", 0);
            su.Set("bn_locked", "false",true);
            su.Set("ts_locked", (DateTime?)null);
            su.Set("nt_login_cnt", "nt_login_cnt+1", true);
            su.Set("ts_last_login", DateTime.Now);
            su.Set("nt_r_ver", "nt_r_ver+1", true);
            su.Where = "ng_id=@ng_id";
            su.AddParam("@ng_id", userId);
            su.ExecuteNonQuery();
        }

        public void SetLoginFailed(IDbSession sess, long userId, bool locked)
        {
            SqlUpdate su = new SqlUpdate(sess);
            su.Sql = "sys_user_t";
            su.Set("nt_fcnt", "nt_fcnt+1");
            su.Set("bn_locked", locked?"true":"false",true);
            if (locked)
            {
                su.Set("ts_locked", DateTime.Now.AddDays(1));
            }
            su.Set("nt_r_ver", "nt_r_ver+1", true);
            su.Where = "ng_id=@ng_id";
            su.AddParam("@ng_id", userId);
            su.ExecuteNonQuery();
        }

    }
}
