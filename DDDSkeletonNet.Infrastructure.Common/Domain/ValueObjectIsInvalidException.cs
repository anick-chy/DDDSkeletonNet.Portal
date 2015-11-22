using System;

namespace DDDSkeletonNet.Infrastructure.Common.Domain
{
    /// <summary>
    /// Represent errors that occur if any value object is invalid
    /// </summary>
    public class ValueObjectIsInvalidException : Exception
    {
        /// <summary>
        /// Represent errors that occur if any value object is invalid
        /// </summary>
        public ValueObjectIsInvalidException(string message)
            : base(message) { }
    }
}
