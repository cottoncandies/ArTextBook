using System;
using System.Collections.Generic;
using System.Text;

namespace Alva.ArTextBook.Kernel.Types
{
    public enum ModuleKind
    {
        #region 公共基础：不显示为菜单
        /// <summary>
        /// 集合可以嵌套
        /// </summary>
        VGroup = 1,
        /// <summary>
        /// 模块对应一个特定的页面
        /// </summary>
        VModule = 2,
        /// <summary>
        /// 操作对应一个按钮
        /// </summary>
        VOP = 4,
        #endregion

        #region 模块定义： 显示为菜单
        /// <summary>
        /// 集合可以嵌套
        /// </summary>
        Group = 16,
        /// <summary>
        /// 模块对应一个特定的页面
        /// </summary>
        Module = 32,
        /// <summary>
        /// 操作对应一个按钮
        /// </summary>
        OP = 64,
        #endregion

        #region API类型
        /// <summary>
        /// 集合可以嵌套
        /// </summary>
        AGroup = 128,
        /// <summary>
        /// API模块是一个API的集合
        /// </summary>
        AModule = 256,
        /// <summary>
        /// API接口是一个API的调用
        /// </summary>
        API = 512,
        #endregion

        #region Func类型
        /// <summary>
        /// 功能标志集合
        /// </summary>
        FGroup = 1024,
        /// <summary>
        /// 功能标志模块
        /// </summary>
        FModule = 2048,
        /// <summary>
        /// 功能标志
        /// </summary>
        Func = 4096
        #endregion
    }
}
