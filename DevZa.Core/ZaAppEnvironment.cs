using DevZa.Configuration;

namespace DevZa
{
    public static class ZaAppEnvironment
    {
        public static  SystemEnvironment Environment { get;  private set; }

        public static bool IsTesting => Environment.Equals(SystemEnvironment.Testing);

        public static bool IsProduction => Environment.Equals(SystemEnvironment.Production);

        public static bool IsStaging => Environment.Equals(SystemEnvironment.Stage);

        public static int AppID => ZaConfigurationManager.ZaAppConfig.Application.AppID;

        static ZaAppEnvironment()
        {
            Environment = ZaConfigurationManager.ZaAppConfig.Enviroment.Env;
        }
    }
}
