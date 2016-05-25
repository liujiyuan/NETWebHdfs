using DevZa.Logger;

namespace DevZa.Security
{
    public class ConfigEncrypt
    {
        private static readonly IZaLogger _log = LoggerFactory.GetLogger<ConfigEncrypt>();

        public static void DecryptConfig(System.Configuration.Configuration config, string[] sectionNames)
        {
            foreach (var sectionName in sectionNames)
            {
                var section = config.GetSection(sectionName);
                if (section.SectionInformation.IsProtected)
                {
                    section.SectionInformation.UnprotectSection();
                }
            }

            config.Save();
        }

        public static void EncryptConfig(System.Configuration.Configuration config, string[] sectionNames)
        {
            foreach (var sectionName in sectionNames)
            {
                var section = config.GetSection(sectionName);
                if (!section.SectionInformation.IsProtected)
                {
                    _log.DebugFormat("Encrypt Configuration Section {0}", sectionName);
                    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                }
                else
                {
                    _log.DebugFormat("Section {0} has been Encrypt", sectionName);
                }
            }
            config.Save();
        }
    }
}