using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConnectLibrary.Responses
{
    public enum OperationResult
    {
        Successful,
        Error,
        IncompleteData,
        Maintenance,
        NotFound,
        Invalid
    }
}
