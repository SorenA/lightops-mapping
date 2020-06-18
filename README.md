# LightOps.Mapping

Mapping package for .NET Standard.

## Concepts

The package defines the following concepts.

### Mapper interface - `IMapper`

Mapper interface to implement and register in the service provider to allow usage from the mapping service.

### Mapping service `IMappingService`

Resolves mappers using the `IMapper` interface using the source and destination type in the service provider.  

Map using `IMappingService.Map<TSource, TDest>(source)`, supports both single and enumerable sources.
Throws a `MapperNotFoundException` if no mapper is found.
