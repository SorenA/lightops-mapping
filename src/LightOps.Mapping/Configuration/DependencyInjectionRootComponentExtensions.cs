using System;
using LightOps.DependencyInjection.Configuration;

namespace LightOps.Mapping.Configuration
{
    public static class DependencyInjectionRootComponentExtensions
    {
        public static IDependencyInjectionRootComponent AddMapping(this IDependencyInjectionRootComponent rootComponent, Action<IMappingComponent> componentConfig = null)
        {
            var component = new MappingComponent();

            // Invoke config delegate
            componentConfig?.Invoke(component);

            // Attach to root component
            rootComponent.AttachComponent(component);

            return rootComponent;
        }
    }
}