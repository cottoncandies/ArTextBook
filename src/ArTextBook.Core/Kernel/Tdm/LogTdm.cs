using Alva.ArTextBook.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alva.ArTextBook.Kernel.Tdm
{    
    public class LogTdm
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public int ModuleId { get; set; }
        public int? FuncId { get; set; }
        public int Result { get; set; }
        public string Caption { get; set; }
        public string Content { get; set; }
        public DateTime TimeCreate { get; set; } = DateTime.Now;
    }
}
