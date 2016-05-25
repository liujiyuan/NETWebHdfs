using System.Configuration;
using DevZa.aHadoop.Resources;

namespace DevZa.aHadoop.Configuration
{
    public class UserElement : ConfigurationElement
    {
        [ConfigurationProperty(HadoopConfigurationConstants.User.Id)]
        public string Id
        {
            get { return (string)this[HadoopConfigurationConstants.User.Id]; }
            set { this[HadoopConfigurationConstants.User.Id] = value; }
        }


        [ConfigurationProperty(HadoopConfigurationConstants.User.Password)]
        public string Password
        {
            get { return (string)this[HadoopConfigurationConstants.User.Password]; }
            set { this[HadoopConfigurationConstants.User.Password] = value; }
        }
    }
}