using System;

namespace ECom.Common.Services
{

    [Serializable]
    public class ProxyCallException : Exception
    {
        public string Resource { get; set; }
        public ProxyCallException(string resource) { Resource = resource; }
        public ProxyCallException(string resource, string message) : base(message) { Resource = resource; }
        public ProxyCallException(string resource, string message, Exception inner) : base(message, inner) { Resource = resource; }
        protected ProxyCallException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
