using Alva.ArTextBook.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alva.ArTextBook.Kernel.Tdm
{
    public class ConfigTdm : EntityBase
    {        
        public string Key { get; set; }
        public long? UserId { get; set; }
        public string UserName { get; set; }
        public String Value { get; set; }        
    }
}
