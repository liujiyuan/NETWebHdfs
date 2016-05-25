using DevZa.aHadoop.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevZa.aHadoop.CoreTests.Configuration
{
    [TestClass()]
    public class AHadoopConfigurationManagerTests
    {
        private AHadoopConfig AHadoopConfig = AHadoopConfigurationManager.AHadoopConfig;

        private AHadoopUserInfoConfig UserInfoConfig = AHadoopConfigurationManager.UserInfoConfig;

        [TestMethod()]
        public void GetConfigurationTest()
        {
            Assert.AreEqual("10.10.19.40", AHadoopConfig.ActiveHadoopNode.Ip);

            Assert.AreEqual("hadoop", UserInfoConfig.User.Id);

            Assert.AreEqual("hadoop", UserInfoConfig.User.Password);

            Assert.AreEqual(false,AHadoopConfig.WebHdfs.SaveMode);

            Assert.AreEqual(50070, AHadoopConfig.WebHdfs.NameNodePort);

            Assert.AreEqual(50075, AHadoopConfig.WebHdfs.DataNodePort);

            Assert.AreEqual("webhdfs/v1",AHadoopConfig.WebHdfs.ApiPrefix);

            Assert.AreEqual("10.10.19.43",AHadoopConfig.FirstDataNode.Ip);
        }
    }
}