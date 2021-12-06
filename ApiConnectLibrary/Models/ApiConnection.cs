using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConnectLibrary.Models
{
    public class ApiConnection
    {

        public string Name { get; set; }
        public string Url { get; set; }
        public List<Header> Headers { get; set; }

    }
}
