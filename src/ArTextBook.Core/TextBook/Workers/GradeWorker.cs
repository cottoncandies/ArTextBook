using Alva.ArTextBook.Types;
using Scietec.Combine.Data;
using Scietec.Combine.Inject;
using Alva.ArTextBook.Kernel.Where;
using Alva.ArTextBook.TextBook.Tdm;
using System.Collections.Generic;

namespace Alva.ArTextBook.TextBook.Workers
{
    [Repository]
    public class GradeWorker : WorkerBase
    {
        #region SQL
        private const string SelectGrade = @"
        select 
	        g.ng_id as Id,
	        g.sz_caption as Caption,
            g.nt_section as Section,
            g.sz_insti as Insti,
	        g.ng_ctor_id as CreatorId,
	        uc.sz_uname as CreatorName,	
	        g.ng_uper_id as UpdaterId,
	        uu.sz_uname as UpdaterName,
	        g.ts_create as TimeCreate,
	        g.ts_update as TimeUpdate,
	        g.nt_r_state as RowState,
	        g.nt_r_ver as RowVersion
        from atb_grade_t g left join sys_user_t uc on g.ng_ctor_id=uc.ng_id
	        left join sys_user_t uu on g.ng_uper_id=uu.ng_id
    ";
        #endregion

        public Pagable<GradeTdm> Find(IDbSession sess, UserWhere where)
        {
            return null;
        }

        public GradeTdm FindById(IDbSession sess, long id)
        {
            SqlSelect ss = new SqlSelect(sess);
            ss.Sql = SelectGrade;
            ss.Where = "u.ng_id=@userId";
            ss.AddParam("@userId", id);
            return ss.ExecuteSingle<GradeTdm>();
        }

        public List<GradeTdm> GetAll(IDbSession sess)
        {
            SqlSelect ss = new SqlSelect(sess);
            ss.Sql = SelectGrade;
            return ss.ExecuteList<GradeTdm>();
        }

        //public void Save(IDbSession sess, GradeTdm user)
        //{
        //    if (user.Id == 0)
        //    {
        //        user.Id = sess.GetNextSequence("sys_user__id__seq");
        //    }

        //    SqlInsert ss = new SqlInsert(sess);
        //    ss.Sql = "sys_user_t";
        //    ss.Set("sz_uname", user.UserName)
        //       .Set("sz_nkname", user.NickName)
        //       .Set("sz_pwd", user.Password)
        //       .Set("sz_email", user.Email)
        //       .Set("sz_mobile", user.Mobile)
        //       .Set("nt_kind", (int)user.Kind)
        //       .Set("nt_gender", (int)user.Gender)
        //       .Set("sz_slogan", user.Slogan)
        //       .Set("sz_avatar", user.Avatar)
        //       .Set("ng_ctor_id", user.CreatorId)
        //       .Set("ng_uper_id", user.UpdaterId)
        //       .Set("ng_id", user.Id);
        //    ss.ExecuteNonQuery();
        //}

        //public void Update(IDbSession sess, GradeTdm user)
        //{
        //    var ss = new SqlUpdate(sess);
        //    ss.Sql = "sys_user_t";
        //    ss.Where = "ng_id=@ng_id";
        //    ss.Set("sz_uname", user.UserName)
        //       .Set("sz_nkname", user.NickName)
        //       .Set("sz_email", user.Email)
        //       .Set("sz_mobile", user.Mobile)
        //       .Set("nt_kind", (int)user.Kind)
        //       .Set("nt_gender", (int)user.Gender)
        //       .Set("sz_slogan", user.Slogan)
        //       .Set("sz_avatar", user.Avatar)
        //       .Set("ng_uper_id", user.UpdaterId)
        //       .AddParam("ng_id", user.Id);
        //    ss.ExecuteNonQuery();
        //}
    }
}
