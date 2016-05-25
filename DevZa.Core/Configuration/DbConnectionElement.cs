using System.Configuration;
using DevZa.Resources;

namespace DevZa.Configuration
{
    public class DBConnectionElement : ConfigurationElement
    {
        [ConfigurationProperty(ConfigConstants.ConnectName)]
        public string ConnectionName
        {
            get { return (string) this[(string) ConfigConstants.ConnectName]; }
            set { this[(string) ConfigConstants.ConnectName] = value; }
        }
    }
}
