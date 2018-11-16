using Alva.ArTextBook.Kernel.Types;
using Alva.ArTextBook.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alva.ArTextBook.Kernel.Tdm
{
    public class ModuleTdm
    {
        public int Id { get; set; }
        public int? PId { get; set; }
        public String Caption { get; set; }
        public string Icon { get; set; }
        public ModuleKind Kind { get; set; } = ModuleKind.OP;
        public int Partial { get; set; } = PartialKind.Both;
        public string Uri { get; set; }
        public bool AnonymEnable { get; set; }
        public bool UserEnable { get; set; }
        public int Level { get; set; }
        public int Order { get; set; }
        public string IdPath { get; set; }
        public bool Enable { get; set; }
        public bool Visible { get; set; }
        public string Depends { get; set; }

        public ModuleTdm() { }

        public ModuleTdm(int id)
        {
            this.Id = id;
        }
    }
}
