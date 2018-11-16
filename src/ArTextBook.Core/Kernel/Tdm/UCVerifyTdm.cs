using Alva.ArTextBook.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alva.ArTextBook.Kernel.Tdm
{
    public class UCVerifyTdm
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Code { get; set; }
        public DateTime TimeSend { get; set; }
        public UCVerifyKind Kind { get; set; } = UCVerifyKind.Mobile;
    }
}
