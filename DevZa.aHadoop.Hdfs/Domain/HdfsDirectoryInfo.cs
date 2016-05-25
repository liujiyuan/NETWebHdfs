using System.Collections.Generic;
using DevZa.aHadoop.Hdfs.HadoopWebHdfs;
using DevZa.aHadoop.Ultility;

namespace DevZa.aHadoop.Hdfs.Domain
{
    public class HdfsDirectoryInfo : HdfsObjectInfo
    {
        internal HdfsDirectoryInfo()
        {
        }

        public HdfsDirectoryInfo(FileStatus hdfsstatus, string pathName, IHadoopHdfsService hdfsService) : base(hdfsstatus,pathName,hdfsService)
        {
            
        }

        public bool IsRoot {
            get { return this.Name.Equals("/"); }
        }

        public HdfsDirectoryInfo GetParentDirectoryInfo()
        {
            return _hdfsService.GetDirectoryInformation(LinuxPathUtility.GetAbovePathName(DirectoryName)).Result;
        }

        public List<HdfsObjectInfo> GetDirAndFileListsHdfsObjects()
        { 
            List<HdfsObjectInfo> results = new List<HdfsObjectInfo>();

            var filestatuses = _hdfsService.GetWebHdfsListStatus(FullName).Result.FileStatuses;
            foreach (var fileStatuse in filestatuses.FileStatus)
            {
                if (fileStatuse.GetFileStatusType().Equals(FileStatusType.FILE))
                {
                    results.Add(new HdfsFileInfo(fileStatuse,_pathName,_hdfsService));
                    continue;
                }
                results.Add(new HdfsDirectoryInfo(fileStatuse,_pathName,_hdfsService));
            }
            return results;
        }

        public bool CreateSubFolder(string subfolder)
        {
            return _hdfsService.CreateSubFolder(this,subfolder).Result;
        }

        public bool RemoveSubFolderOrFile(string target,bool recursvie = false )
        {
            return _hdfsService.RemoveSubFolderOrFile(this,target,recursvie).Result;
        }

        public bool PutFileFromLocal(string localFilePath,bool overWrite = true)
        {
            return _hdfsService.PutFileFromLocal(this,localFilePath,overWrite).Result;
        }

        public bool DownloadFile(string fileName, string targetPath="")
        {
            return _hdfsService.DownloadFile(this,fileName,targetPath).Result;
        }
    }
}