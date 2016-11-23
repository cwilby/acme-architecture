using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.Exceptions
{
    [Serializable]
    public class DeleteEntityException : Exception
    {
        public DeleteEntityException() { }
        public DeleteEntityException(string entityName) : base("There was an error deleting that " + entityName) { }
        public DeleteEntityException(string entityName, Exception inner) : base("There was an error deleting that " + entityName, inner) { }
        protected DeleteEntityException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
