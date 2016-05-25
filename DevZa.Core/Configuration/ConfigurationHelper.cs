using System;
using System.Configuration;

namespace DevZa.Configuration
{
    public class ConfigurationHelper
    {
        public static System.Configuration.Configuration OpenMappedExeConfigFile(string filename)
        {
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();

            configFileMap.ExeConfigFilename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                filename);

            return ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
        }

    }
}
