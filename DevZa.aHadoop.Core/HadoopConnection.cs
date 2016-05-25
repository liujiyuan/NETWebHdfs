using DevZa.aHadoop.Configuration;

namespace DevZa.aHadoop
{
    public abstract class HadoopConnection
    {
        protected string _userid;

        protected string _password;

        public HadoopConnection()
        {
            _userid = AHadoopConfigurationManager.UserInfoConfig.User.Id;
            _password = AHadoopConfigurationManager.UserInfoConfig.User.Password;
        }

        public HadoopConnection(string user, string password)
        {
            _userid = user;
            _password = password;
        }

    }
}
