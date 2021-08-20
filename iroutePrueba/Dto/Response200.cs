using System;

namespace iroutePrueba.DTO
{
    public class Response200
    {
        private int code;
        private bool success;
        private string message;
        private Object data;

        public Response200()
        {
        }

        public Response200(string message, object data)
        {
            this.code = 200;
            this.success = true;
            this.message = message;
            this.data = data;
        }

        public int Code { get => code; set => code = value; }
        public bool Success { get => success; set => success = value; }
        public string Message { get => message; set => message = value; }
        public object Data { get => data; set => data = value; }
    }
}
