using System;

namespace LightOps.Mapping.Domain.Exceptions
{
    public class MapperNotFoundException : Exception
    {
        private readonly Type _sourceType;
        private readonly Type _destType;

        public MapperNotFoundException(Type sourceType, Type destType, string message = null)
            : base(message ?? $"Mapper not found for mapping from {sourceType} to {destType}.")
        {
            _sourceType = sourceType;
            _destType = destType;
        }
    }
}