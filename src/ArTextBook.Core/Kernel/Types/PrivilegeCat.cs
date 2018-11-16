using Alva.ArTextBook.Kernel.Vdm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alva.ArTextBook.Kernel.Types
{
    public class PrivilegeCat
    {
        /// <summary>
        /// 公共执行模块
        /// </summary>
        public List<ModuleVdm> Publics { get; } = new List<ModuleVdm>();
        /// <summary>
        /// 主菜单模块
        /// </summary>
        public List<ModuleVdm> Menus { get; } = new List<ModuleVdm>();
        /// <summary>
        /// 授权API
        /// </summary>
        public List<ModuleVdm> Apis { get; } = new List<ModuleVdm>();
        /// <summary>
        /// 授权标志
        /// </summary>
        public List<ModuleVdm> Funcs { get; } = new List<ModuleVdm>();

        public Dictionary<string, ModuleVdm> UriMap { get; } = new Dictionary<string, ModuleVdm>();

        public ModuleVdm GetModuleByUri(String uri)
        {
            return UriMap.ContainsKey(uri) ? UriMap[uri] : null;
        }
    }
}
