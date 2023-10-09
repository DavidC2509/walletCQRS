﻿namespace Core.Domain.Exceptions
{
    public abstract class ServiceException : Exception
    {
        public abstract int HttpStatusCode { get; }
        public abstract string ErrorMessage { get; }

        public abstract Dictionary<string, List<string>> Errors { get; }
    }
}
