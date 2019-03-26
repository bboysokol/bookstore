using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Result
{
    public class Result<T> : Response
    {
        public T Payload { get; set; }
    }
}
