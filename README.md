# LightOps.Mapping

Mapping package for .NET Standard.

![Nuget](https://img.shields.io/nuget/v/LightOps.Mapping)

| Branch | CI |
| --- | --- |
| master | ![Build Status](https://dev.azure.com/sorendev/LightOps%20Packages/_apis/build/status/SorenA.lightops-mapping?branchName=master) |
| develop | ![Build Status](https://dev.azure.com/sorendev/LightOps%20Packages/_apis/build/status/SorenA.lightops-mapping?branchName=develop) |

## Concepts

The package defines the following concepts.

### Mapper interface - `IMapper`

Mapper interface used to resolve mappers in the service container.

### Mapping service - `IMappingService` and implementation `MappingService`

Resolves mappers using the `IMapper` interface using the source and destination types in the service container.  
Throws a `MapperNotFoundException` if no mapper is found.

Map either of the following:

- `IMappingService.Map<TSource, TDest>(TSource source)`
- `IMappingService.Map<TSource, TDest>(IEnumerable<TSource> source)`

## Attaching the component

Register during startup through the `AddMapping` extension on `IDependencyInjectionRootComponent`.

```csharp
// Add root component
services.AddLightOpsDependencyInjection(root =>
{
    // Add component
    root.AddMapping(component =>
    {
        // Configure component
        // ...
    });

    // Register other components
    // ...
});
```

Overrides may be registered in the component configurator action, see `IMappingComponent` for documentation.

### Required component dependencies

- `LightOps.DependencyInjection` - 0.1.x
