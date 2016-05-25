using System;
using System.Configuration;
using DevZa.Resources;

namespace DevZa.Configuration
{
    public class ApplicationElement : ConfigurationElement
    {
        [ConfigurationProperty(ConfigConstants.ApplicationName,  IsRequired = true)]
        public String Name
        {
            get
            {
                return (String)this[ConfigConstants.ApplicationName];
            }
            set
            {
                this[ConfigConstants.ApplicationName] = value;
            }
        }

        [ConfigurationProperty(ConfigConstants.ApplicationAppId, IsRequired = true)]
        public int AppID
        {
            get
            {
                return (int)this[ConfigConstants.ApplicationAppId];
            }
            set
            {
                this[ConfigConstants.ApplicationAppId] = value;
            }
        }

        
    }
}
