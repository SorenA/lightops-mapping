using System.Collections.Generic;
using System.Linq;
using LightOps.DependencyInjection.Api.Configuration;
using LightOps.DependencyInjection.Domain.Configuration;
using LightOps.Mapping.Api.Services;
using LightOps.Mapping.Domain.Services;

namespace LightOps.Mapping.Configuration
{
    public class MappingComponent : IDependencyInjectionComponent, IMappingComponent
    {
        public string Name => "lightops.mapping";

        public IReadOnlyList<ServiceRegistration> GetServiceRegistrations()
        {
            return new List<ServiceRegistration>()
                .Union(_services.Values)
                .ToList();
        }

        #region Services
        internal enum Services
        {
            MappingService,
        }

        private readonly Dictionary<Services, ServiceRegistration> _services = new Dictionary<Services, ServiceRegistration>
        {
            [Services.MappingService] = ServiceRegistration.Scoped<IMappingService, MappingService>(),
        };

        public IMappingComponent OverrideMappingService<T>()
            where T : IMappingService
        {
            _services[Services.MappingService].ImplementationType = typeof(T);
            return this;
        }
        #endregion Services
    }
}