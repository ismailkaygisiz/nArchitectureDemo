﻿namespace Core.CrossCuttingConcerns.Exceptions.Types
{
    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException() { }
        public BusinessException(string message) : base(message) { }
        public BusinessException(string message, Exception inner) : base(message, inner) { }
    }
}
