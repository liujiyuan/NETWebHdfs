using DevZa.aHadoop.Hdfs.HadoopWebHdfs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevZa.aHadoop.HdfsTests
{
    [TestClass()]
    public class WebHdfsHttpClientTests
    {
        [TestMethod()]
        public void HttpClientCreateSubFolderTest()
        {
            NameNodeHttpClient client = new NameNodeHttpClient();
            var result =client.CreateSubFolder("/tmp/NewCreate").Result;
            Assert.AreEqual(true,result);

            var res =client.DeleteSubFolderOrFile("/tmp/NewCreate").Result;
            Assert.AreEqual(true, res);
        }
    }
}