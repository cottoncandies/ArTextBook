using Alva.ArTextBook.Kernel.Tdm;
using Alva.ArTextBook.Types;
using Scietec.Combine.Data;
using Scietec.Combine.Inject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alva.ArTextBook.Kernel.Workers
{
    [Repository]
    public class LogWorker : WorkerBase
    {
        public void Save(IDbSession sess, LogTdm log, bool queryId = false)
        {
            SqlInsert inse = new SqlInsert(sess);
            inse.Sql = "sys_log_t";
            inse.Set("ng_user_id", log.UserId)
                .Set("nt_mod_id", log.ModuleId)
                .Set("nt_func_id", log.FuncId)
                .Set("nt_result", log.Result)
                .Set("sz_cap", log.Caption)
                .Set("tx_log", log.Content)
                .Set("ts_create", log.TimeCreate);
            inse.ExecuteNonQuery();
            if (queryId)
            {
                log.Id = sess.GetLastInsertId();
            }
        }

        public void Save(IDbSession sess, long userId, int modId,
            int? funcId,int result, string caption, string context)
        {
            SqlInsert inse = new SqlInsert(sess);
            inse.Sql = "sys_log_t";
            inse.Set("ng_user_id", userId)
                .Set("nt_mod_id", modId)
                .Set("nt_func_id", funcId)
                .Set("nt_result", result)
                .Set("sz_cap", caption)
                .Set("tx_log", context);
            inse.ExecuteNonQuery();
        }
    }
}
