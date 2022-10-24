using System.Threading.Tasks;
using Nop.Core.Domain.Customers;
using Nop.Services.Plugins;

namespace Nop.Services.Catalog
{
    public interface IProductSearchPluginManager : IPluginManager<IProductSearchProvider>
    {
        /// <summary>
        /// Load primary active product search provider
        /// </summary>
        /// <param name="customer">Filter by customer; pass null to load all plugins</param>
        /// <param name="storeId">Filter by store; pass 0 to load all plugins</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the ax provider
        /// </returns>
        Task<IProductSearchProvider> LoadPrimaryPluginAsync(Customer customer = null, int storeId = 0);

        /// <summary>
        /// Check whether the passed product search provider is active
        /// </summary>
        /// <param name="productSearchProvider">Product search provider to check</param>
        /// <returns>Result</returns>
        bool IsPluginActive(IProductSearchProvider productSearchProvider);

        /// <summary>
        /// Check whether the product search provider with the passed system name is active
        /// </summary>
        /// <param name="systemName">System name of product search provider to check</param>
        /// <param name="customer">Filter by customer; pass null to load all plugins</param>
        /// <param name="storeId">Filter by store; pass 0 to load all plugins</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the result
        /// </returns>
        Task<bool> IsPluginActiveAsync(string systemName, Customer customer = null, int storeId = 0);
    }
}