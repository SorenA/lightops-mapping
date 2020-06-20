# LightOps.Mapping

Mapping package for .NET Standard.

![Nuget](https://img.shields.io/nuget/v/LightOps.Mapping)

## Concepts

The package defines the following concepts.

### Mapper interface - `IMapper`

Mapper interface used to resolve mappers in the service provider.

### Mapping service - `IMappingService` and implementation `MappingService`

Resolves mappers using the `IMapper` interface using the source and destination types in the service provider.  
Throws a `MapperNotFoundException` if no mapper is found.

Map either of the following:

- `IMappingService.Map<TSource, TDest>(TSource source)`
- `IMappingService.Map<TSource, TDest>(IEnumerable<TSource> source)`
