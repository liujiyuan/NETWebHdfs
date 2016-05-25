using System.Threading.Tasks;
using DevZa.aHadoop.Hdfs.Domain;
using DevZa.aHadoop.Hdfs.HadoopWebHdfs;

namespace DevZa.aHadoop.Hdfs
{
    public interface IHadoopHdfsService
    {
        Task<HdfsDirectoryInfo> GetDirectoryInformation(string path);

        Task<HdfsFileInfo> GetFileInformation(string filename);

        Task<WebHdfsListsStatus> GetWebHdfsListStatus(string fileOrPath);

        Task<WebHdfsFileStatus> GetWebHdfsGetFileStatus(string fileOrPath);

        Task<bool> CreateSubFolder(HdfsDirectoryInfo parent, string subfolderName);

        Task<bool> RemoveSubFolderOrFile(HdfsDirectoryInfo parent, string removeTarget, bool recursive = false);

        Task<bool> PutFileFromLocal(HdfsDirectoryInfo hdfsDirectoryInfo, string localFilePath, bool overWrite=true);

        Task<bool> DownloadFile(HdfsDirectoryInfo hdsDirectoryInfo, string fileName, string targetPath="");
    }

    
}