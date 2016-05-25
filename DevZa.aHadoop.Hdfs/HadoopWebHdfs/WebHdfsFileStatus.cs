using DevZa.aHadoop.Hdfs.Domain;

namespace DevZa.aHadoop.Hdfs.HadoopWebHdfs
{
    public class WebHdfsFileStatus
    {
        public FileStatus FileStatus { get; set; }

        public FileStatusType GetFileStatusType()
        {
            return FileStatus.GetFileStatusType();
        }
    }
}