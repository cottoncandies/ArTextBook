using Microsoft.EntityFrameworkCore;
using Alva.ArTextBook.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Scietec.Combine.Inject;
using Alva.ArTextBook.Kernel.Workers;
using Scietec.Combine.Data;

namespace Alva.ArTextBook.Kernel.Services
{
    [Repository]
    public class RoleService: ServiceBase
    {
        [Autowired]
        RoleWorker roleWorker = null;

        public void AddToRole(long userId, long roleId)
        {
            DbSessionManager.Execute<int>((IDbSession sess) => {
                roleWorker.AddToRole(sess, userId, roleId);
                return 0;
            });
        }

        public void RemoveFromRole(long userId, long roleId)
        {
            DbSessionManager.Execute<int>((IDbSession sess) => {
                roleWorker.RemoveFromRole(sess, userId, roleId);
                return 0;
            });
        }
    }
}
