using System;
using System.Threading.Tasks;

namespace DevZa.aHadoop.Hdfs.HadoopWebHdfs
{
    internal interface INameNodeHttpClient:IDisposable
    {
        Task<bool> CreateSubFolder(string subpath);

        Task<bool> DeleteSubFolderOrFile(string subpath, bool recursive =false);

        Task<WebHdfsFileStatus> GetWebHdfsGetFileStatus(string fileOrPath);

        Task<WebHdfsListsStatus> GetWebHdfsListStatus(string fileOrPath);

        Task<bool> PutLocalFile(string filenameWithPath, byte[] bytes, bool overwrite = true);

        Task<byte[]> WebHdfsOpenFile(string fileWithPath);
    }
}