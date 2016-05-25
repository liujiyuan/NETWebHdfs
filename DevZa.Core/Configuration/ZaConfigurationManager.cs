using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevZa.Logger;
using DevZa.Resources;

namespace DevZa.Configuration
{
    public class ZaConfigurationManager
    {
        private static IZaLogger _log = LoggerFactory.GetLogger<ZaConfigurationManager>();

        private static System.Configuration.Configuration _config;

        static ZaConfigurationManager()
        {
            try
            {
                _config = ConfigurationHelper.OpenMappedExeConfigFile(ConfigConstants.ZaAppConfigFileName);

                _log.Info("Load ZaApp.config successful!!");

                if (_config.HasFile == false) throw new Exception(
                    $"Can't find configuration file for DevZa system under file location: {_config.FilePath}");

                EncrypSection(_config);
            }
            catch (Exception)
            {
                _log.Fatal("Fatal Load ZaApp.config file");
                throw;
            }
        }

        public static void EncrypSection(System.Configuration.Configuration config)
        {
            _log.Debug("Configuration Section Startup");
            try
            {
                List<string> securitList = new List<string>() { "connectionStrings" };

                foreach (ConfigurationSection section in config.Sections)
                {
                    if (section.SectionInformation.Name.Contains("Security"))
                    {
                        _log.DebugFormat("Add New Security Section :{0}", section.SectionInformation.Name);
                        securitList.Add(section.SectionInformation.Name);
                    }
                }

                Security.ConfigEncrypt.EncryptConfig(config, securitList.ToArray());
            }
            catch (Exception ex)
            {
                _log.ErrorParm("init error", ex);
            }
        }

        public static AppSettingsSection AppSettings => _config.AppSettings;

        public static ConnectionStringsSection ConnectionStrings => _config.ConnectionStrings;

        public static ZaAppConfig ZaAppConfig => (ZaAppConfig)_config.GetSection(ConfigConstants.ZaAppConfigSectionName);

        public static System.Configuration.Configuration GetConfiguration => _config;

        public static ConfigurationSection GetConfigurationSectionByName(string sectionName)
        {
            return _config.GetSection(sectionName);
        }
    }
}
