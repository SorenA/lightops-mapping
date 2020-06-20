# LightOps.Mapping

Mapping package for .NET Standard.

## Concepts

The package defines the following concepts.

### Mapper interface - `IMapper`

Mapper interface to implement and register in the service provider to allow usage from the mapping service.

### Mapping service `IMappingService`

Resolves mappers using the `IMapper` interface using the source and destination type in the service provider.  

Throws a `MapperNotFoundException` if no mapper is found.

Map either of the following:

- `IMappingService.Map<TSource, TDest>(TSource source)`
- `IMappingService.Map<TSource, TDest>(IEnumerable<TSource> source)`.  
