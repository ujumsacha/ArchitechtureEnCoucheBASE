using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BdFolder
{
    public class AppConfigSetting : IAppConfigSetting
    {
        private readonly IConfiguration _configuration; 

        public AppConfigSetting(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? Defaultconnection
        {
            get
            {
                return this._configuration["ConnectionStrings:myDb1"];
            }
        }
        public IConfigurationSection GetConfigurationSection(string Key)
        {
            return this._configuration.GetSection(Key);
        }
        
        public string? GetConnectionString(string connectionName)
        {
            return this._configuration.GetConnectionString(connectionName);
        }
    }
}
