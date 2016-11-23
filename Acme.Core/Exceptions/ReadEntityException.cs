using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.Exceptions
{
    [Serializable]
    public class ReadEntityException : Exception
    {
        public ReadEntityException() { }
        public ReadEntityException(string entityName) : base("There was an error getting that " + entityName) { }
        public ReadEntityException(string entityName, Exception inner) : base("There was an error getting that " + entityName, inner) { }
        protected ReadEntityException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
