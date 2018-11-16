using Newtonsoft.Json;

namespace Alva.ArTextBook.TextBook.Vdm
{
    public class UploadVdm
    {
        [JsonProperty("grade")]
        public string Grade { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("publish")]
        public string Publish { get; set; }

        [JsonProperty("edition")]
        public string Edition { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
