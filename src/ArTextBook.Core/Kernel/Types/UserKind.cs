using System;
using System.Collections.Generic;
using System.Text;

namespace Alva.ArTextBook.Kernel.Types
{
    public enum UserKind
    {
        /// <summary>
        /// 0：虚拟账户（运行时所需，不能用于登陆）
        /// </summary>
        Virtual = 0,
        /// <summary>
        /// 1：系统定义（系统定义，不能删除）
        /// </summary>
        System = 1,
        /// <summary>
        /// 2：用户添加
        /// </summary>
        User = 2
    }
}
