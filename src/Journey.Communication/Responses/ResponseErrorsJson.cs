using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Communication.Responses
{
    public class ResponseErrorsJson
    {
        public IList<string> Errors { get; set; } = [];

        public ResponseErrorsJson(IList<string> erros)
        {
            Errors = erros;
        }
    }
}
