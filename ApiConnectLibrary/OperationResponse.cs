using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConnection.Objects
{
    public class OperationResponse<T>
    {

        public T value { get; set; }

        public string detail { get; set; }

        public OperationResult result { get; set; }


        public OperationResponse() {
            result = OperationResult.Successful;
        }

        public OperationResponse(T value)
        {
            this.value = value;
            result = OperationResult.Successful;
        }

        public OperationResponse(T value, OperationResult result, string detail)
        {
            this.value = value;
            this.detail = detail;
            this.result = result;
        }

    }
}
