using Scietec.Combine.Data;
using Scietec.Combine.Inject;
using Alva.ArTextBook.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alva.ArTextBook.Kernel.Workers
{
    [Repository]
    public class RoleWorker : WorkerBase
    {

        public void AddToRole(IDbSession sess, long userId,long roleId)
        {
            SqlUpsert us = new SqlUpsert(sess);
            us.Sql = "sys_user_role_t";
            us.ConflictTarget = "ng_user_id,ng_role_id";
            us.Set("ng_user_id", userId, true, false)
                .Set("ng_role_id", roleId, true, false);
            us.ExecuteNonQuery();
        }

        public void RemoveFromRole(IDbSession sess, long userId, long roleId)
        {
            SqlDelete us = new SqlDelete(sess);
            us.Sql = "sys_user_role_t";
            us.Where = "ng_user_id=@ng_user_id and ng_role_id=@ng_role_id";
            us.AddParam("@ng_user_id", userId)
                .AddParam("@ng_role_id", roleId);
            us.ExecuteNonQuery();
        }
    }
}
