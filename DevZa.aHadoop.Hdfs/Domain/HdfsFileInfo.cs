using DevZa.aHadoop.Hdfs.HadoopWebHdfs;

namespace DevZa.aHadoop.Hdfs.Domain
{
    public class HdfsFileInfo:HdfsObjectInfo
    {
        public HdfsFileInfo()
        {
        }

        public HdfsFileInfo(FileStatus hdfsstatus, string pathName, IHadoopHdfsService hdfsService) : base(hdfsstatus,pathName,hdfsService)
        {
        }

        public HdfsDirectoryInfo GetContainDirectoryInfo()
        {
            return _hdfsService.GetDirectoryInformation(DirectoryName).Result;
        }
    }
}