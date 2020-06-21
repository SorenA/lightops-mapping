using System.Collections.Generic;
using LightOps.Mapping.Api.Services;

namespace LightOps.Mapping.Test.Mock
{
    public class NullMappingService : IMappingService
    {
        public TDest Map<TSource, TDest>(TSource source) where TSource : class where TDest : class
        {
            return null;
        }

        public IEnumerable<TDest> Map<TSource, TDest>(IEnumerable<TSource> source) where TSource : class where TDest : class
        {
            return null;
        }
    }
}