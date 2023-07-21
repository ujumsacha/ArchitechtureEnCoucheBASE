using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BdFolder
{
    public interface IAppConfigSetting
    {
        string? Defaultconnection { get; }

        string? GetConnectionString(string connectionName);

        IConfigurationSection GetConfigurationSection(string Key);
    }
}
