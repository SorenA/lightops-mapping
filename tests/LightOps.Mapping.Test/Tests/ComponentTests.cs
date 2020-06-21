using LightOps.DependencyInjection.Api.Providers;
using LightOps.DependencyInjection.Configuration;
using LightOps.Mapping.Api.Services;
using LightOps.Mapping.Configuration;
using LightOps.Mapping.Test.Mock;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LightOps.Mapping.Test.Tests
{
    public class ComponentTests
    {
        [Fact]
        public void TestComponent_IsAttached()
        {
            var services = new ServiceCollection();

            // Add component
            services.AddLightOpsDependencyInjection(root =>
            {
                root.AddMapping();
            });

            var serviceProvider = services.BuildServiceProvider();

            // Get 
            var dependencyInjectionComponentStateProvider = serviceProvider.GetService<IDependencyInjectionComponentStateProvider>();

            Assert.Contains("lightops.mapping",
                dependencyInjectionComponentStateProvider.AttachedComponentNames);
        }

        [Fact]
        public void TestComponent_Configuration_Invoked()
        {
            var services = new ServiceCollection();

            // Add component
            var invoked = false;
            services.AddLightOpsDependencyInjection(root =>
            {
                root.AddMapping(component =>
                {
                    invoked = true;
                });
            });

            var serviceProvider = services.BuildServiceProvider();

            Assert.True(invoked);
        }

        [Fact]
        public void TestComponent_Override_MappingService()
        {
            var services = new ServiceCollection();

            // Add component
            services.AddLightOpsDependencyInjection(root =>
            {
                root.AddMapping(component =>
                {
                    component.OverrideMappingService<NullMappingService>();
                });
            });

            var serviceProvider = services.BuildServiceProvider();

            Assert.IsType<NullMappingService>(serviceProvider.GetService<IMappingService>());
        }
    }
}