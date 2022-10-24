using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Services.Plugins;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// Provides an interface for creating product search provider
    /// </summary>
    public interface IProductSearchProvider : IPlugin
    {
        /// <summary>
        /// Get products identifiers by the specified keywords
        /// </summary>
        /// <param name="keywords">Keywords</param>
        /// <returns>The task result contains product identifiers</returns>
        Task<List<int>> SearchProductsAsync(string keywords);
    }
}