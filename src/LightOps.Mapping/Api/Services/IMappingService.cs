using System.Collections.Generic;

namespace LightOps.Mapping.Api.Services
{
    public interface IMappingService
    {
        TDest Map<TSource, TDest>(TSource source)
            where TSource : class
            where TDest : class;
        IEnumerable<TDest> Map<TSource, TDest>(IEnumerable<TSource> source)
            where TSource : class
            where TDest : class;
    }
}