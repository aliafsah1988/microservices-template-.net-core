using System;

namespace ServiceA.Business.Exceptions
{
    public abstract class SampleException : Exception
    {
        public SampleException(string message)
            : base(message)
        { }

        public abstract int ErrorCode { get; }
    }

    public class CustomeException : SampleException
    {
        public CustomeException()
        : base($"Unkwon Error")
        { }

        public override int ErrorCode =>500;
    }
}
