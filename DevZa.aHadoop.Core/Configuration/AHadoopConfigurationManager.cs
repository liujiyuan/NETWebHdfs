using System;
using DevZa.aHadoop.Resources;
using DevZa.Configuration;
using DevZa.Logger;

namespace DevZa.aHadoop.Configuration
{
    public class AHadoopConfigurationManager
    {
        private static IZaLogger _log = LoggerFactory.GetLogger<AHadoopConfigurationManager>();

        private static System.Configuration.Configuration _config;

        static AHadoopConfigurationManager()
        {
            try
            {
                _config = ConfigurationHelper.OpenMappedExeConfigFile(HadoopConfigurationConstants.ConfigFileName);

                _log.Info("Load Hadoop Configuration File successful!!");

                if (_config.HasFile == false) throw new Exception(string.Format(@"Can't find Hadoop configuration file under file location: {0}", _config.FilePath));

                ZaConfigurationManager.EncrypSection(_config);
            }
            catch (Exception ex)
            {
                _log.Fatal("Fatal Load aHadoop.config file", ex);
                throw new Exception("Fatal load aHadoop Config file ", ex);
            }
        }

        
        public System.Configuration.Configuration GetConfiguration()
        {
            return _config;
        }

        public static AHadoopConfig AHadoopConfig
        {
            get { return (AHadoopConfig)_config.GetSection(HadoopConfigurationConstants.ConfigSectionName); }
        }

        public static AHadoopUserInfoConfig UserInfoConfig
        {

            get { return (AHadoopUserInfoConfig)_config.GetSection(HadoopConfigurationConstants.UserInfoConfigSectionName); }
        }
    }
}
