using System.Configuration;
using DevZa.Resources;

namespace DevZa.Configuration
{
    public class ZaAppConfig: BaseConfigurationSection
    {
        [ConfigurationProperty(ConfigConstants.Application)]
        public ApplicationElement Application
        {
            get
            {
                return (ApplicationElement)this[ConfigConstants.Application];
            }
            set
            { this[ConfigConstants.Application] = value; }
        }


        [ConfigurationProperty(ConfigConstants.Environment)]
        public EnviromentElement Enviroment
        {
            get
            {
                return (EnviromentElement)this[ConfigConstants.Environment];
            }
            set
            { this[ConfigConstants.Environment] = value; }
        }
    }
}