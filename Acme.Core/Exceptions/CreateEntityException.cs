using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.Exceptions
{
    [Serializable]
    public class CreateEntityException : Exception
    {
        public CreateEntityException() { }
        public CreateEntityException(string entityName) : base("There was an error creating that " + entityName) { }
        public CreateEntityException(string entityName, Exception inner) : base("There was an error creating that " + entityName, inner) { }
        protected CreateEntityException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
