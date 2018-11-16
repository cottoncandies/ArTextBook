using System;
using System.Collections.Generic;
using System.Text;

namespace Alva.ArTextBook.Types
{
    public class WorkerBase
    {
        public string GetDayBeginString(DateTime t)
        {
            return t.ToString("yyyy-MM-dd") + " 0:0:0";
        }

        public string GetDayEndString(DateTime t)
        {
            return t.ToString("yyyy-MM-dd") + " 23:59:59";
        }
    }
}
