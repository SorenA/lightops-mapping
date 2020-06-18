using System;
using System.Collections.Generic;
using System.Linq;
using LightOps.Mapping.Api.Mappers;
using LightOps.Mapping.Api.Services;
using LightOps.Mapping.Domain.Exceptions;

namespace LightOps.Mapping.Domain.Services
{
    public class MappingService : IMappingService
    {
        private readonly IServiceProvider _serviceProvider;

        public MappingService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TDest Map<TSource, TDest>(TSource source)
            where TSource : class
            where TDest : class
        {
            if (source == null)
            {
                return null;
            }

            var mapper = _serviceProvider.GetService(typeof(IMapper<TSource, TDest>)) as IMapper<TSource, TDest>;
            if (mapper == null)
            {
                throw new MapperNotFoundException(typeof(TSource), typeof(TDest));
            }

            return mapper.Map(source);
        }

        public IEnumerable<TDest> Map<TSource, TDest>(IEnumerable<TSource> source)
            where TSource : class
            where TDest : class
        {
            if (source == null)
            {
                return null;
            }

            var mapper = _serviceProvider.GetService(typeof(IMapper<TSource, TDest>)) as IMapper<TSource, TDest>;
            if (mapper == null)
            {
                throw new MapperNotFoundException(typeof(TSource), typeof(TDest));
            }

            return source
                .Select(mapper.Map)
                .ToList();
        }
    }
}