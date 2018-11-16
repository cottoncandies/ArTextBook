using Alva.ArTextBook.Kernel.Tdm;
using Alva.ArTextBook.Types;
using Scietec.Combine.Data;
using Scietec.Combine.Inject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Alva.ArTextBook.Kernel.Workers
{
    [Repository]
    public class ModuleWorker : WorkerBase
    {
        #region SQL
        private const string SelectModule = @"
            select
	            m.ng_id as Id,
	            m.ng_p_id as PId,
	            m.sz_cap as Caption,
	            m.sz_icon as Icon,
	            m.nt_kind as Kind,
                m.nt_partial as Partial,
	            m.sz_uri as Uri,
	            m.bn_anonym  as AnonymEnable, 
	            m.bn_user  as UserEnable, 
	            m.nt_level as Level,
	            m.nt_order as Order,
	            m.sz_id_path as IdPath,
	            m.bn_enable as Enable,
	            m.bn_visible as Visible, 
	            m.sz_deps as Depends	
            from sys_module_t m
        ";
        private const string OrderBy = " nt_kind asc,nt_level asc,nt_order asc ";
        #endregion

        /// <summary>
        /// All
        /// </summary>
        /// <param name="sess"></param>
        /// <returns></returns>
        public List<ModuleTdm> GetAllModules(IDbSession sess)
        {
            List<ModuleTdm> r = new List<ModuleTdm>();
            SqlSelect ss = new SqlSelect(sess);
            ss.Sql = SelectModule;
            ss.OrderBy = OrderBy;
            return ss.ExecuteList<ModuleTdm>();
        }

        /// <summary>
        /// 含MENU And API for Anonymous
        /// </summary>
        /// <param name="sess"></param>
        /// <returns></returns>
        public List<ModuleTdm> GetAnonymModules(IDbSession sess)
        {
            List<ModuleTdm> r = new List<ModuleTdm>();
            SqlSelect ss = new SqlSelect(sess);
            ss.Sql = SelectModule;
            ss.Where = "m.bn_anonym=true";
            ss.OrderBy = OrderBy;
            return ss.ExecuteList<ModuleTdm>();
        }
      
        /// <summary>
        /// For User,Menu And API
        /// </summary>
        /// <param name="sess"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ModuleTdm> GetUserModules(IDbSession sess,long userId)
        {
            string existsSql = @"
                exists(
	                select mr.ng_mod_id from sys_role_mod_t mr where exists(
		                SELECT ru.ng_role_id from sys_user_role_t ru 
                        where mr.ng_role_id=ru.ng_role_id and ru.ng_user_id=@userId
	                ) and m.ng_id=mr.ng_mod_id
                )";
            List<ModuleTdm> r = new List<ModuleTdm>();
            SqlSelect ss = new SqlSelect(sess);
            ss.Sql = SelectModule;
            ss.Where = "m.bn_anonym=true or m.bn_user=true or "+ existsSql;
            ss.OrderBy = OrderBy;
            ss.AddParam("@userId", userId);
            return ss.ExecuteList<ModuleTdm>();
        }
    }
}
