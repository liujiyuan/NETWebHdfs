using System.Linq;
using DevZa.aHadoop.Hdfs;
using DevZa.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevZa.aHadoop.HdfsTests
{
    [TestClass]
    public class HadoopHdfsManagerTests
    {
        private static IZaLogger _log = LoggerFactory.GetLogger<HadoopHdfsManagerTests>();

        [TestMethod]
        public void GetFileStatusesTest()
        {
            var manager = new HadoopHdfsManager();

            //WebHdfsListsStatus list = manager.GetWebHdfsListStatus("/tmp").Result;

            //Assert.AreEqual(6, list.FileStatuses.FileStatus.Count);

            var status = manager.GetWebHdfsGetFileStatus("/user/etu/elitest").Result;

            Assert.AreEqual("FILE", status.FileStatus.type);

            var status2 = manager.GetWebHdfsGetFileStatus("/user/etu").Result;

            Assert.AreEqual("DIRECTORY", status2.FileStatus.type);
        }


        [TestMethod]
        public void GetDirectoryTest()
        {
            IHadoopHdfsService manager = new HadoopHdfsManager();

            var info = manager.GetDirectoryInformation("/user/etu/elitest").Result;

            Assert.AreEqual(null, info);

            var info2 = manager.GetDirectoryInformation("/").Result;

            Assert.AreEqual(4, info2.GetDirAndFileListsHdfsObjects().Where(t => t.IsDirectory).ToList().Count);


            //HdfsDirectoryInfo info3 = manager.GetDirectoryInformation("/user/etu").Result;
            //Assert.AreEqual(15, info3.GetParentDirectoryInfo().ChildernCount);
        }

        [TestMethod]
        public void GetFileInfoTest()
        {
            IHadoopHdfsService manager = new HadoopHdfsManager();

            var file = manager.GetFileInformation("/user/etu").Result;

            Assert.AreEqual(null, file);

            var file2 = manager.GetFileInformation("/user/etu/elitest").Result;

            LoggerHelper.Debug(file2.DirectoryName);
            Assert.AreEqual("/user/etu", file2.DirectoryName);

            Assert.AreEqual(5, file2.GetContainDirectoryInfo().GetDirAndFileListsHdfsObjects().Count);
        }

        [TestMethod]
        public void CreateSubFolderTest()
        {
            IHadoopHdfsService manager = new HadoopHdfsManager();

            var info = manager.GetDirectoryInformation("/tmp").Result;

            Assert.AreEqual(true, info.CreateSubFolder("NewFolder"));

            var info2 = manager.GetDirectoryInformation("/tmp/NewFolder").Result;
            Assert.AreEqual("NewFolder", info2.Name);

            Assert.AreEqual(true, info.RemoveSubFolderOrFile("NewFolder"));

            var info3 = manager.GetDirectoryInformation("/tmp/NewFolder").Result;
            Assert.AreEqual(null, info3);
        }

        [TestMethod]
        public void PutFileFromLocalTest()
        {
            IHadoopHdfsService manager = new HadoopHdfsManager();

            var info = manager.GetDirectoryInformation("/tmp").Result;

            var result = info.PutFileFromLocal(@"D:\temp\Sample.txt");

            Assert.AreEqual(true, result);

            Assert.AreEqual(false, info.PutFileFromLocal(@"D:\temp\Sample.txt", false));

            info.RemoveSubFolderOrFile("Sample.txt");
        }


        [TestMethod]
        public void DownloadFile()
        {
            IHadoopHdfsService manager = new HadoopHdfsManager();

            var info = manager.GetDirectoryInformation("/tmp").Result;

            info.DownloadFile("9F.pptx");
        }

        [TestMethod]
        public void RemoveSubFolderOrFileTest()
        {
            IHadoopHdfsService manager = new HadoopHdfsManager(new WebHdfsRestfulConnection("impala", ""));
            var info = manager.GetDirectoryInformation("/tmp/impala/QueryAndInsert").Result;
            var result = manager.RemoveSubFolderOrFile(info, "QueryAndInsertP100000", true);
            result = manager.RemoveSubFolderOrFile(info, "QueryAndInsertT100000", true);
        }
    }
}