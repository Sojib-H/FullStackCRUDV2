using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dummy2.Model.Common
{
    public class ResponseParam
    {
        public string ResponseCode { get; set; }
        public string ResponseMsg { get; set; }
        public dynamic ResponseData { get; set; }
    }
}
