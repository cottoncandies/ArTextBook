using Newtonsoft.Json;
using Alva.ArTextBook.Kernel.Types;
using Alva.ArTextBook.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alva.ArTextBook.Kernel.Vdm
{
    public class ModuleVdm
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonIgnore]
        public ModuleVdm Parent { get; set; }
        [JsonProperty("caption")]
        public String Caption { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("kind")]
        public ModuleKind Kind { get; set; } = ModuleKind.OP;
        [JsonProperty("partial")]
        public int Partial { get; set; } = PartialKind.Both;
        [JsonProperty("uri")]
        public string Uri { get; set; }
        [JsonProperty("anonymEnable")]
        public bool AnonymEnable { get; set; }
        [JsonProperty("userEnable")]
        public bool UserEnable { get; set; }
        [JsonProperty("depends")]
        public string Depends { get; set; }
        [JsonProperty("childs")]
        public List<ModuleVdm> Childs { get; } = new List<ModuleVdm>();
    }
}
