using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Programa
{
    class Response<T>
    {
        public IList<T> Results { get; set; }

        public IList<T> Result { get; set; }
    }

}
