using LightOps.Mapping.Api.Services;

namespace LightOps.Mapping.Configuration
{
    /// <summary>
    /// Mapping dependency injection component
    /// </summary>
    public interface IMappingComponent
    {
        #region Services
        /// <summary>
        /// Overrides mapping service with implementation of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of the implementation</typeparam>
        /// <returns>Returns component for chaining</returns>
        IMappingComponent OverrideMappingService<T>() where T : IMappingService;
        #endregion Services
    }
}