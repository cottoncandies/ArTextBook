using Alva.ArTextBook.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Scietec.Combine.Inject;

namespace Alva.ArTextBook.Kernel.Services
{
    [Repository]
    public class LogService: ServiceBase
    {        
        //public void Add(long userId, string caption, LogKind kind, string context)
        //{
        //    var log = new LogItem();
        //    var u = new User(userId);
        //    log.User = u;
        //    log.Caption = caption;
        //    log.Kind = kind;
        //    log.Content = context;
        //    log.TimeCreate = DateTime.Now;
        //    SetState(u, EntityState.Unchanged);
        //    Add(log);
        //}

        //public void Save(long userId, string caption, LogKind kind, string context)
        //{
        //    Add(userId, caption, kind, context);
        //    SaveChanges();
        //}
    }
}
