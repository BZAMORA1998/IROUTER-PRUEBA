using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iroutePrueba.DTO
{
    public class ResponseError
    {
        private int code;
        private bool success;
        private string message;
        private Object errordata;

        public ResponseError(int code, string message, object errordata)
        {
            this.code = code;
            this.success = false;
            this.message = message;
            this.errordata = errordata;
        }

        public int Code { get => code; set => code = value; }
        public bool Success { get => success; set => success = value; }
        public string Message { get => message; set => message = value; }
        public object Errordata { get => errordata; set => errordata = value; }
    }
}
