using System;

namespace Netbasics.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException()
        {
        }

        public ObjectNotFoundException(string message)
            : base(message)
        {
        }

        public ObjectNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ObjectNotFoundException(Type objectType)
            : base(objectType.ToString())
        {
        }

        public ObjectNotFoundException(Type objectType, object id)
            : base(objectType + " | ID: " + id)
        {
        }
    }
}