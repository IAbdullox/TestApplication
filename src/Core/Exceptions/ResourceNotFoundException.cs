using System.Runtime.Serialization;

namespace Core.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() { }
        public ResourceNotFoundException(Type type) : base($"{type} is missing") { }
        public ResourceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public ResourceNotFoundException(string message) : base(message) { }
        public ResourceNotFoundException(string? message, Exception? exception) : base(message, exception) { }
    }
}
