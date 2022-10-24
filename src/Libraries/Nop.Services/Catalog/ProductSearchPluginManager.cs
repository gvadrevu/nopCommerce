using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Services.Customers;
using Nop.Services.Plugins;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// Represents a product search plugin manager implementation
    /// </summary>
    public class ProductSearchPluginManager : PluginManager<IProductSearchProvider>, IProductSearchPluginManager
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;

        #endregion

        #region Ctor

        public ProductSearchPluginManager(CatalogSettings catalogSettings, ICustomerService customerService, IPluginService pluginService)
                : base(customerService, pluginService)
        {
            _catalogSettings = catalogSettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Load primary active product search provider
        /// </summary>
        /// <param name="customer">Filter by customer; pass null to load all plugins</param>
        /// <param name="storeId">Filter by store; pass 0 to load all plugins</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the ax provider
        /// </returns>
        public virtual async Task<IProductSearchProvider> LoadPrimaryPluginAsync(Customer customer = null, int storeId = 0)
        {
            return await LoadPrimaryPluginAsync(_catalogSettings.ActiveProductSearchProviderSystemName, customer, storeId);
        }

        /// <summary>
        /// Check whether the passed product search provider is active
        /// </summary>
        /// <param name="productSearchProvider">Product search provider to check</param>
        /// <returns>Result</returns>
        public virtual bool IsPluginActive(IProductSearchProvider productSearchProvider)
        {
            return IsPluginActive(productSearchProvider, new List<string> { _catalogSettings.ActiveProductSearchProviderSystemName });
        }

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
        public virtual async Task<bool> IsPluginActiveAsync(string systemName, Customer customer = null, int storeId = 0)
        {
            var productSearchProvider = await LoadPluginBySystemNameAsync(systemName, customer, storeId);
            return IsPluginActive(productSearchProvider);
        }

        #endregion
    }
}