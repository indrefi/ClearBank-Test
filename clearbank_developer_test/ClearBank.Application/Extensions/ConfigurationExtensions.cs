using ClearBank.Application.Common.Constants;
using Microsoft.Extensions.Configuration;

namespace ClearBank.Application.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetDataStorageTypeConfigurationOrDefault(this IConfiguration Configuration) =>
            string.IsNullOrEmpty(Configuration.GetSection("DataStoreType").Value) ?
                ConfigrationConstants.BackUp :
                Configuration.GetSection("DataStoreType").Value;
        
    }
}
