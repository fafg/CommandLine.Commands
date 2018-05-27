using System;

namespace CommandLine.Commands
{
    internal class NoMatchingCommandException : Exception
    {
        public NoMatchingCommandException()
        {
        }

        public NoMatchingCommandException(string message) : base(message)
        {
        }

        public NoMatchingCommandException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}