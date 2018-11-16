using System;
using System.Collections.Generic;
using System.Text;

namespace Alva.ArTextBook.Types
{
    public class MethodResult<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public bool Ok
        {
            get
            {
                return Code == 0;
            }
        }

        public static MethodResult<T> Successful(T data)
        {
            var r = new MethodResult<T>();
            r.Code = 0;
            r.Message = "Successful";
            r.Data = data;
            return r;
        }

        public static MethodResult<T> Failed(string message)
        {
            var r = new MethodResult<T>();
            r.Code = -1;
            r.Message = message;
            r.Data = default(T);
            return r;
        }
    }
}
