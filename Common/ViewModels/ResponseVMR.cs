using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class ResponseVMR<T>
    {
        public HttpStatusCode code { get; set; }

        public T data { get; set; }
        public List<string> mesages { get; set; }

        public ResponseVMR() 
        {
            code = HttpStatusCode.OK;
            data = default(T);
            mesages = new List<string>();
        }
    }
}
