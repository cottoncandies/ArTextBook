using System;

namespace Alva.ArTextBook.Kernel.Vdm
{
    public class ErrorVdm
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}