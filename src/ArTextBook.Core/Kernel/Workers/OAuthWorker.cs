using Scietec.Combine.Data;
using Scietec.Combine.Inject;
using Alva.ArTextBook.Kernel.Tdm;
using Alva.ArTextBook.Kernel.Types;
using Alva.ArTextBook.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alva.ArTextBook.Kernel.Workers
{
    [Repository]
    public class OAuthWorker : WorkerBase
    {
        #region SQL
        const string SelectSQL = @"
            select
	            m.ng_id as Id,
	            m.nt_kind as Kind,
	            m.sz_open_id as OpenId,
	            m.ng_user_id as UserId,
	            m.sz_nick_name as NickName,
	            m.nt_gender as Gender,
	            m.sz_country as Country,
	            m.sz_province as Province,
	            m.sz_city as City,
	            m.sz_language as Language,
	            m.sz_avatar_uri as AvatarUri,
	            m.sz_union_id as UnionId,
	            m.ts_create as TimeCreate,
	            m.ts_update as TimeUpdate,
	            m.nt_r_state as RowState,
	            m.nt_r_ver as RowVersion
            from sys_oauth_t m 
            ";
        #endregion

        public OAuthTdm FindByOpenId(IDbSession sess, OAuthKind kind,string openId)
        {
            SqlSelect ss = new SqlSelect(sess);
            ss.Sql = SelectSQL;
            ss.Where = " m.nt_kind=@nt_kind and m.sz_open_id=@sz_open_id";
            ss.AddParam("@nt_kind", (int)kind).AddParam("@sz_open_id", openId);
            return ss.ExecuteSingle<OAuthTdm>();
        }

        public int Save(IDbSession sess, OAuthTdm tdm)
        {
            SqlInsert ss = new SqlInsert(sess);
            ss.Sql = "sys_oauth_t";
            //ss.ConflictTarget = "nt_kind,sz_open_id";
            ss.Set("ng_id",tdm.Id)
                .Set("nt_kind", (int)tdm.Kind)
                .Set("sz_open_id", tdm.OpenId)
                .Set("ng_user_id", tdm.UserId)
                .Set("sz_nick_name", tdm.NickName)
                .Set("nt_gender", (int)tdm.Gender)
                .Set("sz_country", tdm.Country)
                .Set("sz_province", tdm.Province)
                .Set("sz_city", tdm.City)
                .Set("sz_language", tdm.Language)
                .Set("sz_avatar_uri", tdm.AvatarUri)
                .Set("sz_union_id", tdm.UnionId);
            return ss.ExecuteNonQuery();
        }

        public int Update(IDbSession sess, OAuthTdm tdm)
        {
            var ss = new SqlUpdate(sess);
            ss.Sql = "sys_oauth_t";
            ss.Where = "ng_id=@ng_id";
            //ss.ConflictTarget = "nt_kind,sz_open_id";
            ss.Set("nt_kind", (int)tdm.Kind)
                .Set("sz_open_id", tdm.OpenId)
                .Set("ng_user_id", tdm.UserId)
                .Set("sz_nick_name", tdm.NickName)
                .Set("nt_gender", (int)tdm.Gender)
                .Set("sz_country", tdm.Country)
                .Set("sz_province", tdm.Province)
                .Set("sz_city", tdm.City)
                .Set("sz_language", tdm.Language)
                .Set("sz_avatar_uri", tdm.AvatarUri)
                .Set("sz_union_id", tdm.UnionId)
                .AddParam("@ng_id",tdm.Id);
            return ss.ExecuteNonQuery();
        }
    }
}
