using Newtonsoft.Json;
using Alva.ArTextBook.Kernel.Types;
using Alva.ArTextBook.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alva.ArTextBook.Kernel.Tdm
{    
    public class RoleTdm : EntityBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public RoleKind Kind { get; set; } = RoleKind.UserUser;

        public RoleTdm() { }

        public RoleTdm(long id)
        {
            this.Id = id;
        }
    }
}
