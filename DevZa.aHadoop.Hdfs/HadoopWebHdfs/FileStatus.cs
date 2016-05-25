using System;
using DevZa.aHadoop.Hdfs.Domain;

namespace DevZa.aHadoop.Hdfs.HadoopWebHdfs
{
    public class FileStatus
    {
        public long accessTime { get; set; }
        public long blockSize { get; set; }
        public int childrenNum { get; set; }
        public int fileId { get; set; }
        public string group { get; set; }
        public int length { get; set; }
        public long modificationTime { get; set; }
        public string owner { get; set; }
        public string pathSuffix { get; set; }
        public string permission { get; set; }
        public int replication { get; set; }
        public string type { get; set; }

        public FileStatusType GetFileStatusType()
        {
            return (FileStatusType)Enum.Parse(typeof(FileStatusType), type);
        }
    }
}