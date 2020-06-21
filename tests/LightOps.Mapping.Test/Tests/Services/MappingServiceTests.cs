using System.Collections.Generic;
using System.Linq;
using LightOps.Mapping.Api.Mappers;
using LightOps.Mapping.Domain.Exceptions;
using LightOps.Mapping.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LightOps.Mapping.Test.Tests.Services
{
    public class MappingServiceTests
    {
        public class SourceModel
        {
            public string Value { get; set; }
        }

        public class DestinationModel
        {
            public string Value { get; set; }
        }

        public class TestMapper : IMapper<SourceModel, DestinationModel>
        {
            public DestinationModel Map(SourceModel source)
            {
                return new DestinationModel
                {
                    Value = source.Value,
                };
            }
        }

        [Fact]
        public void TestMapper_NotFound()
        {
            var services = new ServiceCollection();
            var serviceProvider = services.BuildServiceProvider();

            var mappingService = new MappingService(serviceProvider);

            var source = new SourceModel
            {
                Value = "value",
            };

            Assert.Throws<MapperNotFoundException>(() => mappingService.Map<SourceModel, DestinationModel>(source));
        }

        [Fact]
        public void TestMapper_Enumerable_NotFound()
        {
            var services = new ServiceCollection();
            var serviceProvider = services.BuildServiceProvider();

            var mappingService = new MappingService(serviceProvider);

            var sources = new List<SourceModel>
            {
                new SourceModel
                {
                    Value = "value",
                },
                new SourceModel
                {
                    Value = "other",
                },
            };

            Assert.Throws<MapperNotFoundException>(() => mappingService.Map<SourceModel, DestinationModel>(sources));
        }

        [Fact]
        public void TestMapper_Found()
        {
            var services = new ServiceCollection();
            services.AddScoped<IMapper<SourceModel, DestinationModel>, TestMapper>();
            var serviceProvider = services.BuildServiceProvider();

            var mappingService = new MappingService(serviceProvider);

            var source = new SourceModel
            {
                Value = "value",
            };
            var destination = mappingService.Map<SourceModel, DestinationModel>(source);

            Assert.NotNull(destination);
            Assert.IsType<DestinationModel>(destination);
            Assert.Equal("value", destination.Value);
        }

        [Fact]
        public void TestMapper_Enumerable_Found()
        {
            var services = new ServiceCollection();
            services.AddScoped<IMapper<SourceModel, DestinationModel>, TestMapper>();
            var serviceProvider = services.BuildServiceProvider();

            var mappingService = new MappingService(serviceProvider);

            var sources = new List<SourceModel>
            {
                new SourceModel
                {
                    Value = "value",
                },
                new SourceModel
                {
                    Value = "other",
                },
            };
            var destinations = mappingService.Map<SourceModel, DestinationModel>(sources)
                .ToList();

            Assert.NotNull(destinations);
            Assert.Equal(2, destinations.Count);
            Assert.IsType<DestinationModel>(destinations[0]);
            Assert.IsType<DestinationModel>(destinations[1]);
            Assert.Equal("value", destinations[0].Value);
            Assert.Equal("other", destinations[1].Value);
        }

        [Fact]
        public void TestMapper_Null()
        {
            var services = new ServiceCollection();
            services.AddScoped<IMapper<SourceModel, DestinationModel>, TestMapper>();
            var serviceProvider = services.BuildServiceProvider();

            var mappingService = new MappingService(serviceProvider);

            SourceModel source = null;
            var destination = mappingService.Map<SourceModel, DestinationModel>(source);

            Assert.Null(destination);
        }

        [Fact]
        public void TestMapper_Enumerable_Null()
        {
            var services = new ServiceCollection();
            services.AddScoped<IMapper<SourceModel, DestinationModel>, TestMapper>();
            var serviceProvider = services.BuildServiceProvider();

            var mappingService = new MappingService(serviceProvider);

            List<SourceModel> sources = null;
            var destinations = mappingService.Map<SourceModel, DestinationModel>(sources);

            Assert.Null(destinations);
        }

        [Fact]
        public void TestMapper_Enumerable_NullElement()
        {
            var services = new ServiceCollection();
            services.AddScoped<IMapper<SourceModel, DestinationModel>, TestMapper>();
            var serviceProvider = services.BuildServiceProvider();

            var mappingService = new MappingService(serviceProvider);

            var sources = new List<SourceModel>
            {
                new SourceModel
                {
                    Value = "value",
                },
                null,
            };
            var destinations = mappingService.Map<SourceModel, DestinationModel>(sources)
                .ToList();

            Assert.NotNull(destinations);
            Assert.Equal(2, destinations.Count);
            Assert.IsType<DestinationModel>(destinations[0]);
            Assert.Null(destinations[1]);
            Assert.Equal("value", destinations[0].Value);
        }
    }
}