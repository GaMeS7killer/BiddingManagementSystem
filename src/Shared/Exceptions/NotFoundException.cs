// Shared/Exceptions/NotFoundException.cs
using System;

namespace BiddingManagementSystem.Shared.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName, object key)
            : base($"{entityName} with identifier '{key}' was not found.") { }
    }
}
