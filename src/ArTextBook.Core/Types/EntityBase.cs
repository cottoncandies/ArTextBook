using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Alva.ArTextBook.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Alva.ArTextBook.Kernel.Tdm;

namespace Alva.ArTextBook.Types
{
    public class EntityBase
    {
        public long? CreatorId { get; set; }
        public string CreatorName { get; set; }
        public long? UpdaterId { get; set; }
        public string UpdaterName { get; set; }
        public DateTime TimeCreate { get; set; }
        public DateTime TimeUpdate { get; set; }
        public RowState RowState { get; set; } = RowState.Normal;
        public int RowVersion { get; set; } = 1;
    }
}
