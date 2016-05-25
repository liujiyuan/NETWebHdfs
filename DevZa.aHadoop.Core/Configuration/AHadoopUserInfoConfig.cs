using System.Configuration;
using DevZa.aHadoop.Resources;
using DevZa.Configuration;

namespace DevZa.aHadoop.Configuration
{
    public class AHadoopUserInfoConfig:BaseConfigurationSection
    {
        [ConfigurationProperty(HadoopConfigurationConstants.UserElement)]
        public UserElement User
        {
            get { return (UserElement)this[HadoopConfigurationConstants.UserElement]; }

            set { this[HadoopConfigurationConstants.UserElement] = value; }
        }

    }
}
