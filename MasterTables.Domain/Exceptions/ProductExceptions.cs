﻿namespace MasterTables.Domain.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) : base(message) { }
    }

    public class ProductAlreadyExistsException : Exception
    {
        public ProductAlreadyExistsException(string? message) : base(message)
        {
        }
    }

    public class ProductValidationException : Exception
    {
        public ProductValidationException(string message) : base(message) { }
    }
}
