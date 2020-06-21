namespace LightOps.Mapping.Api.Mappers
{
    /// <summary>
    /// Mapper for mapping from type <typeparamref name="TSource"/> to type <typeparamref name="TDest"/>
    /// </summary>
    /// <typeparam name="TSource">The source type to map from</typeparam>
    /// <typeparam name="TDest">The destination type to map to</typeparam>
    public interface IMapper<in TSource, out TDest>
    {
        /// <summary>
        /// Maps entity of type <typeparamref name="TSource"/> to type <typeparamref name="TDest"/>
        /// </summary>
        /// <param name="source">Source entity to map from</param>
        /// <returns>Returns source entity mapped to destination type</returns>
        TDest Map(TSource source);
    }
}