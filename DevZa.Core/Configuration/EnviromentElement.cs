using System.Configuration;
using DevZa.Resources;

namespace DevZa.Configuration
{
    public class EnviromentElement : ConfigurationElement
    {
        [ConfigurationProperty(ConfigConstants.EnvironmentEnv, DefaultValue = SystemEnvironment.Testing, IsRequired = true)]
        public SystemEnvironment Env
        {
            get
            {
                return (SystemEnvironment)this[ConfigConstants.EnvironmentEnv];
            }
            set
            {
                this[ConfigConstants.EnvironmentEnv] = value;
            }
        }


        [ConfigurationProperty(ConfigConstants.EnableDbLog,DefaultValue =false,IsRequired = false)]
        public bool EnableDbLog
        {
            get { return (bool) this[ConfigConstants.EnableDbLog]; }
            set { this[ConfigConstants.EnableDbLog] = value; }
        }
    }
}
