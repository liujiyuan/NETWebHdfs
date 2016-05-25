using System;
using System.IO;
using System.Threading.Tasks;
using DevZa.aHadoop.Hdfs.Domain;
using DevZa.aHadoop.Hdfs.HadoopWebHdfs;
using DevZa.Logger;

namespace DevZa.aHadoop.Hdfs
{
    public class HadoopHdfsManager : IHadoopHdfsService, IDisposable
    {
        private static IZaLogger _log = LoggerFactory.GetLogger<HadoopHdfsManager>();

        private  WebHdfsRestfulConnection _connection;

        public HadoopHdfsManager() : this(new WebHdfsRestfulConnection())
        {
        }

        public HadoopHdfsManager(WebHdfsRestfulConnection connection)
        {
            _connection = connection;
        }

        public async Task<HdfsDirectoryInfo> GetDirectoryInformation(string path)
        {
            var filestatus = await GetWebHdfsGetFileStatus(path);
            if (filestatus == null)
            {
                _log.DebugFormat("path not full, path:{0}",path);
                return null;
            }
            if (filestatus.GetFileStatusType().Equals(FileStatusType.FILE))
            {
                _log.DebugFormat("Get Directory: {0} is an File, Not a Directory",path);
                return null;
            }
            HdfsDirectoryInfo directoryInfo = new HdfsDirectoryInfo(filestatus.FileStatus,path,this);
            return directoryInfo;
        }

        public async Task<HdfsFileInfo> GetFileInformation(string filename)
        {
            var filestatus = await GetWebHdfsGetFileStatus(filename);
            if (filestatus.GetFileStatusType().Equals(FileStatusType.DIRECTORY))
            {
                _log.DebugFormat("Get File: {0} is an Directory, Not a File", filename);
                return null;
            }
            var result = new HdfsFileInfo(filestatus.FileStatus,filename,this);

            return result;
        }

        public async Task<WebHdfsListsStatus> GetWebHdfsListStatus(string fileOrPath)
        {
            using (INameNodeHttpClient _hdfsHttpClient = new NameNodeHttpClient())
            {
                return await _hdfsHttpClient.GetWebHdfsListStatus(fileOrPath);
            }
        }

        public async Task<WebHdfsFileStatus> GetWebHdfsGetFileStatus(string fileOrPath)
        {
            using (INameNodeHttpClient _hdfsHttpClient = new NameNodeHttpClient())
            {
                return await _hdfsHttpClient.GetWebHdfsGetFileStatus(fileOrPath); 
            }
        }

        public async Task<bool> CreateSubFolder(HdfsDirectoryInfo parent, string subfolderName)
        {
            CheckHdfsDirectoryInfo(parent);
            using (INameNodeHttpClient _hddHdfsHttpClient =new NameNodeHttpClient())
            {
                var creatpath = string.Format("{0}/{1}", parent.DirectoryName, subfolderName);
                return await _hddHdfsHttpClient.CreateSubFolder(creatpath);
            }
        }

        private void CheckHdfsDirectoryInfo(HdfsDirectoryInfo parent)
        {
            if (parent==null) throw new Exception("HdfsDirectoryInfo Should not be null"); 
        }

        public async Task<bool> RemoveSubFolderOrFile(HdfsDirectoryInfo parent, string removeTarget, bool recursive = false)
        {
            CheckHdfsDirectoryInfo(parent);
            using (INameNodeHttpClient _hddHdfsHttpClient = new NameNodeHttpClient())
            {
                var creatpath = string.Format("{0}/{1}", parent.DirectoryName, removeTarget);
                return await _hddHdfsHttpClient.DeleteSubFolderOrFile(creatpath,recursive);
            }
        }

        public async Task<bool> PutFileFromLocal(HdfsDirectoryInfo hdfsDirectoryInfo, string localFilePath, bool overWrite = true)
        {
            CheckHdfsDirectoryInfo(hdfsDirectoryInfo);
            var fileinfo = new FileInfo(localFilePath);

            if (fileinfo == null)
            {
                throw new Exception("File Not Exist");
            }
            
            using (INameNodeHttpClient _nameNodeHttpClient = new NameNodeHttpClient())
            {
                var filebytes = System.IO.File.ReadAllBytes(localFilePath);

                var remoteFilePath = string.Format("{0}/{1}", hdfsDirectoryInfo.DirectoryName, fileinfo.Name);

                return await _nameNodeHttpClient.PutLocalFile(remoteFilePath,filebytes,overWrite);
            }
        }

        public async Task<bool> DownloadFile(HdfsDirectoryInfo hdsDirectoryInfo, string fileName, string targetPath="")
        {
            CheckHdfsDirectoryInfo(hdsDirectoryInfo);
            if (string.IsNullOrWhiteSpace(targetPath))
              targetPath =AppDomain.CurrentDomain.BaseDirectory;

            using (INameNodeHttpClient _nameNodeHttpClient = new NameNodeHttpClient())
            {
                var remoteFilePath = string.Format("{0}/{1}", hdsDirectoryInfo.DirectoryName, fileName);

                var bytes = await _nameNodeHttpClient.WebHdfsOpenFile(remoteFilePath);

                if (bytes == null) return false;

                var savePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,fileName);

                File.WriteAllBytes(savePath, bytes);

                return true;
            }

        }


        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool dispose)
        {
            if (dispose)
            {
                _connection = null;
            }
        }
    }
}