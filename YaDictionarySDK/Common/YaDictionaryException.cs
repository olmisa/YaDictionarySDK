using System;

namespace YaDictionarySDK.Common
{
    public class YaDictionaryException : Exception
    {
        public YaDictionaryException()
        {
        }

        public YaDictionaryException(string message) : base(message)
        {
        }

        public YaDictionaryException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
