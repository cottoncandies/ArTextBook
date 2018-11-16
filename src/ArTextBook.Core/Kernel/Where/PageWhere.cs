using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alva.ArTextBook.Kernel.Where
{
    public class PageWhere
    {
        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("recordCount")]
        public long RecordCount { get; set; }

        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("skipRecourd")]
        public long SkipRecourd { get; set; }

        [JsonProperty("queryTotal")]
        public bool QueryTotal { get; set; } = true;

    }
}
