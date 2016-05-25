using DevZa.aHadoop.Ultility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevZa.aHadoop.CoreTests.Ultility
{
    [TestClass()]
    public class LinuxPathUtilityTests
    {
        [TestMethod()]
        public void GetAbovePathNameTest()
        {
            var actual = LinuxPathUtility.GetAbovePathName("/test/ok");
            Assert.AreEqual("/test", actual);

            var actual3 = LinuxPathUtility.GetAbovePathName("/test");
            Assert.AreEqual("/", actual3);

            var actual2 = LinuxPathUtility.GetAbovePathName("/test/ok/");
            Assert.AreEqual("/test", actual2);
        }

        [TestMethod()]
        public void GetFolderOrFileNameTest()
        {
            var actual = LinuxPathUtility.GetFolderOrFileName("/test/ok");
            Assert.AreEqual("ok", actual);

            var actual2 = LinuxPathUtility.GetFolderOrFileName("/test/ok/");
            Assert.AreEqual("ok", actual2);
        }
    }
}