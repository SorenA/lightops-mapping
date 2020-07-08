# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.3.1] - 2020-07-08

### Changed

- Remove class constraints from source and destinations of `IMappingService.Map` methods

## [0.3.0] - 2020-07-04

### Changed

- `IMappingService` lifespan changed to transient from scoped

## [0.2.0] - 2020-06-21

### Added

- XML documentation on interfaces
- Test project with unit tests and end-to-end service container registration tests
- Dependency Injection component for service registration in the service container
- `IDependencyInjectionRootComponent` extension `AddMapping` to attach component to root component

## [0.1.0] - 2020-06-20

### Added

- CHANGELOG file
- README file describing project
- Azure Pipelines based CI/CD setup
- `IMapper` interface for implementing mappers
- `IMappingService` and implementation `IMappingService` to map using `IMapper`s in service provider

[unreleased]: https://github.com/SorenA/lightops-mapping/compare/0.3.1...develop
[0.3.1]: https://github.com/SorenA/lightops-mapping/tree/0.3.1
[0.3.0]: https://github.com/SorenA/lightops-mapping/tree/0.3.0
[0.2.0]: https://github.com/SorenA/lightops-mapping/tree/0.2.0
[0.1.0]: https://github.com/SorenA/lightops-mapping/tree/0.1.0
