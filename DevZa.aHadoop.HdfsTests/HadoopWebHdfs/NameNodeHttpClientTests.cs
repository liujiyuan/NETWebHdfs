using DevZa.aHadoop.Hdfs.HadoopWebHdfs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevZa.aHadoop.HdfsTests.HadoopWebHdfs
{
    [TestClass()]
    public class NameNodeHttpClientTests
    {
        private string path = "/tmp/sample.txt";

        [TestMethod()]
        public void HttpClientCreateFileTest()
        {
            NameNodeHttpClient client = new NameNodeHttpClient();

            var file =System.IO.File.ReadAllBytes(@"D:\Temp\Sample.txt");

            var result = client.PutLocalFile(path,file).Result;

            Assert.AreEqual(true,result  );

            var restul2 = client.DeleteSubFolderOrFile(path).Result;
            Assert.AreEqual(true, restul2);
        }

    }
}