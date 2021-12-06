using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConnectLibrary.Models
{
    public class Api
    {

        public ApiConnection _apiConnection;


        public Api(ApiConnection apiConnection) {
            _apiConnection = apiConnection;
        }


        public Dictionary<string, string> GetHeaders()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();

            if (_apiConnection.Headers != null && _apiConnection.Headers.Count > 0) {
                foreach (Header header in _apiConnection.Headers) {
                    headers.Add(header.Key, header.Value);
                }
            }

            return headers;
        }

    }
}
