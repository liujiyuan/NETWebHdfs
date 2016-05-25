using System.Configuration;
using System.Xml;
using DevZa.Resources;

namespace DevZa.Configuration
{
    public abstract class BaseConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty(ConfigConstants.DBConnection, IsRequired = false)]
        public DBConnectionElement DbConnection
        {
            get { return (DBConnectionElement) this[ConfigConstants.DBConnection]; }
            set { this[ConfigConstants.DBConnection] = value; }
        }

        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
        {
            return true;
        }


        protected override bool OnDeserializeUnrecognizedElement(string elementName, XmlReader reader)
        {
            return true;
        }
    }
}