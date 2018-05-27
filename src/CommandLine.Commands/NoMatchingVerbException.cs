using System;

namespace CommandLine.Commands
{
    internal class NoMatchingVerbException : Exception
    {
        public NoMatchingVerbException()
        {
        }

        public NoMatchingVerbException(string message) : base(message)
        {
        }

        public NoMatchingVerbException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}