// Shared/Exceptions/ValidationException.cs
using System;
using System.Collections.Generic;

namespace BiddingManagementSystem.Shared.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException(IDictionary<string, string[]> errors)
            : base("One or more validation errors occurred.")
        {
            Errors = errors;
        }
    }
}
