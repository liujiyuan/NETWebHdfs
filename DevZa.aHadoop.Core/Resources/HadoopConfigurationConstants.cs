namespace DevZa.aHadoop.Resources
{
    internal class HadoopConfigurationConstants
    {
        public class Hosts
        {
            
        }

        public const string ConfigFileName = "aHadoop.Config";
        public const string ConfigSectionName = "aHadoop";
        public const string NameNodesElement = "nameNodes";
        public const string DataNodesElement = "dataNodes";
        public const string UserElement = "user";
        public const string WebHDFSElement = "webhdfs";

        public class User
        {
            public const string Id = "id";
            public const string Password = "password";
        }

        public class NameNode
        {
            public const string Ip = "ip";
            public const string Name = "name";
            public const string Type = "type";
        }

        public class WebHdfs
        {
            public const string NameNodePort = "nameNodePort";
            public const string DataNodePort = "dataNodePort";
            public const string SaveMode = "saveMode";
            public const string ApiPrefix = "apiPrefix";
        }

        public const string UserInfoConfigSectionName = "aHadoopUserInfoSecurity";
    }

   
}
