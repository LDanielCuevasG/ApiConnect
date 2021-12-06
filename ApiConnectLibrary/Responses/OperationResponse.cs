using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConnectLibrary.Responses
{
    public class OperationResponse<T>
    {

        public T Value { get; set; }
        public string Detail { get; set; }
        public OperationResult Result { get; set; }


        public OperationResponse() {
            Result = OperationResult.Successful;
        }

        public OperationResponse(T value)
        {
            Value = value;
            Result = OperationResult.Successful;
        }

        public OperationResponse(T value, OperationResult result, string detail)
        {
            Value = value;
            Detail = detail;
            Result = result;
        }

    }
}
