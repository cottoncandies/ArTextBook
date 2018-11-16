using Alva.ArTextBook.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Scietec.Combine.Inject;
using Alva.ArTextBook.Kernel.Tdm;
using Alva.ArTextBook.Kernel.Workers;
using Scietec.Combine.Data;
using Alva.ArTextBook.Kernel.Types;
using Alva.ArTextBook.Kernel.Vdm;

namespace Alva.ArTextBook.Kernel.Services
{
    [Repository]
    public class ModuleService : ServiceBase
    {
        [Autowired]
        ModuleWorker moduleWorker = null;

        #region ModuleTdm
        /// <summary>
        /// All
        /// </summary>
        /// <param name="sess"></param>
        /// <returns></returns>
        public List<ModuleTdm> GetAllModules()
        {
            return DbSessionManager.Execute<List<ModuleTdm>>((IDbSession sess) =>
            {
                return moduleWorker.GetAllModules(sess);
            });
        }

        /// <summary>
        /// 含MENU And API for Anonymous
        /// </summary>
        /// <param name="sess"></param>
        /// <returns></returns>
        public List<ModuleTdm> GetAnonymModules()
        {
            return DbSessionManager.Execute<List<ModuleTdm>>((IDbSession sess) =>
            {
                return moduleWorker.GetAnonymModules(sess);
            });
        }

        /// <summary>
        /// For User,Menu And API
        /// </summary>
        /// <param name="sess"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ModuleTdm> GetUserModules(long userId)
        {
            return DbSessionManager.Execute<List<ModuleTdm>>((IDbSession sess) =>
            {
                return moduleWorker.GetUserModules(sess, userId);
            });
        }
        #endregion

        #region AuthMap
        public HashSet<string> GetAuthMap(List<ModuleTdm> moduleList)
        {
            var r = new HashSet<string>();
            foreach (var t in moduleList)
            {
                if (t.Enable && !String.IsNullOrEmpty(t.Uri))
                {
                    r.Add(t.Uri);
                }
            }
            return r;
        }

        public HashSet<string> GetAnonymAuthMap()
        {
            return GetAuthMap(GetAnonymModules());
        }

        public HashSet<string> GetUserAuthMap(long userId)
        {
            return GetAuthMap(GetUserModules(userId));
        }
        #endregion

        #region PrivilegeCat

        #region 辅助方法
        private ModuleVdm Tdm2Vdm(ModuleTdm t)
        {
            ModuleVdm v = new ModuleVdm();
            v.Id = t.Id;
            v.Parent = null;
            v.Caption = t.Caption;
            v.Icon = t.Icon;
            v.Kind = t.Kind;
            v.Partial = t.Partial;
            v.Uri = t.Uri;
            v.AnonymEnable = t.AnonymEnable;
            v.UserEnable = t.UserEnable;
            v.Depends = t.Depends;
            return v;
        }

        private void SaveModule2Collect(ModuleTdm t, Dictionary<int, ModuleVdm> mmap,
            List<ModuleVdm> collect, Dictionary<string, ModuleVdm> uriMap)
        {
            var v = Tdm2Vdm(t);          

            if (null == t.PId)
            {
                v.Parent = null;
                mmap.Add(v.Id, v);
                collect.Add(v);
            }
            else if (mmap.ContainsKey(t.PId.Value))
            {
                var pv = mmap[t.PId.Value];
                pv.Childs.Add(v);
                v.Parent = pv;
                mmap.Add(v.Id, v);
            }

            if (!String.IsNullOrEmpty(v.Uri))
            {
                uriMap[v.Uri] = v;
            }
        }

        private void DealWithNotMenuItem(ModuleTdm t,
            Dictionary<int, ModuleVdm> mmap,bool menuOnly, List<ModuleVdm> collect, 
            Dictionary<string, ModuleVdm> uriMap)
        {
            if (!t.Enable || menuOnly)
            {
                return;
            }
            SaveModule2Collect(t, mmap, collect, uriMap);
        }
        #endregion

        public PrivilegeCat ModulesToPrivilegeCat(List<ModuleTdm> mlist,
            bool menuOnly = true)
        {
            Dictionary<int, ModuleVdm> mmap = new Dictionary<int, ModuleVdm>();
            var pc = new PrivilegeCat();
            var publics = pc.Publics;
            var menus = pc.Menus;
            var apis = pc.Apis;
            var funcs = pc.Funcs;
            var uriMap = pc.UriMap;

            foreach (ModuleTdm t in mlist)
            {
                switch (t.Kind)
                {
                    case ModuleKind.VGroup:
                        DealWithNotMenuItem(t, mmap, menuOnly, publics, uriMap);
                        break;
                    case ModuleKind.VModule:
                        goto case ModuleKind.VGroup;
                    case ModuleKind.VOP:
                        goto case ModuleKind.VGroup;
                    case ModuleKind.Group:
                        if (!t.Enable || (menuOnly && !t.Visible))
                        {
                            break;
                        }
                        SaveModule2Collect(t,mmap, menus, uriMap);
                        break;
                    case ModuleKind.Module:
                        goto case ModuleKind.Group;
                    case ModuleKind.OP:
                        DealWithNotMenuItem(t, mmap, menuOnly, menus, uriMap);
                        break;
                    case ModuleKind.AGroup:
                        DealWithNotMenuItem(t, mmap, menuOnly, apis, uriMap);
                        break;
                    case ModuleKind.AModule:
                        goto case ModuleKind.AGroup;
                    case ModuleKind.API:
                        goto case ModuleKind.AGroup;
                    case ModuleKind.FGroup:
                        DealWithNotMenuItem(t, mmap, menuOnly, funcs, uriMap);
                        break;
                    case ModuleKind.FModule:
                        goto case ModuleKind.FGroup;
                    case ModuleKind.Func:
                        goto case ModuleKind.FGroup;
                }  //switch
            } //for each
            return pc;
        }

        public PrivilegeCat GetAllPrivileges(bool menuOnly = true)
        {
            List<ModuleTdm> mlist = GetAllModules();
            return ModulesToPrivilegeCat(mlist, menuOnly);
        }

        public PrivilegeCat GetAnonymPrivileges(bool menuOnly = true)
        {
            List<ModuleTdm> mlist = GetAnonymModules();
            return ModulesToPrivilegeCat(mlist, menuOnly);
        }

        public PrivilegeCat GetUserPrivileges(long userId, bool menuOnly = true)
        {
            List<ModuleTdm> mlist = GetUserModules(userId);
            return ModulesToPrivilegeCat(mlist, menuOnly);
        }
        #endregion


    }
}
