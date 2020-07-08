using System.Collections.Generic;
using LightOps.Mapping.Api.Services;

namespace LightOps.Mapping.Test.Mock
{
    public class NullMappingService : IMappingService
    {
        public TDest Map<TSource, TDest>(TSource source)
        {
            return default;
        }

        public IEnumerable<TDest> Map<TSource, TDest>(IEnumerable<TSource> source)
        {
            return null;
        }
    }
}