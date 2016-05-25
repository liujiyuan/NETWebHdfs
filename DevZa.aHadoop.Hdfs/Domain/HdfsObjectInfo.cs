using System;
using DevZa.aHadoop.Hdfs.HadoopWebHdfs;
using DevZa.aHadoop.Hdfs.Resources;
using DevZa.aHadoop.Ultility;

namespace DevZa.aHadoop.Hdfs.Domain
{
    public abstract class HdfsObjectInfo
    {
        protected readonly FileStatus _hdfsstatus;

        protected string _pathName;

        protected readonly IHadoopHdfsService _hdfsService;

        public HdfsObjectInfo()
        {
        }

        public HdfsObjectInfo(FileStatus hdfsstatus, string pathName, IHadoopHdfsService hdfsService)
        {
            _hdfsstatus = hdfsstatus;
            _pathName = pathName;
            _hdfsService = hdfsService;
        }

        public bool IsDirectory
        {
            get { return _hdfsstatus.type == WebHdfsAPIConstants.FileStatusDefine.Directory; }
        }

        public bool IsFile
        {
            get { return _hdfsstatus.type == WebHdfsAPIConstants.FileStatusDefine.File; }
        }

        public FileStatusType FileStatusType
        {
            get { return _hdfsstatus.GetFileStatusType(); }
        }

        public string Name
        {
            get { return ShortName; }
        }

        public string ShortName
        {
            get { return LinuxPathUtility.GetFolderOrFileName(FullName); }
        }

        public string DirectoryName
        {
            get
            {
                switch (FileStatusType)
                {
                    case FileStatusType.DIRECTORY:
                        return _pathName;
                    case FileStatusType.FILE:
                        return LinuxPathUtility.GetAbovePathName(FullName);
                    default:
                        return _pathName;
                }
            }
        }

        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_hdfsstatus.pathSuffix))
                    return _pathName;

                return string.Format("{0}/{1}", _pathName, _hdfsstatus.pathSuffix);
            }
        }

        public long BlockSize
        {
            get { return _hdfsstatus.blockSize; }
        }

        public int ChildernCount
        {
            get { return _hdfsstatus.childrenNum; }
        }

        public string Type
        {
            get { return _hdfsstatus.type; }
        }

        public DateTime? ModifyDateTime
        {
            get { return LinuxTimeStampUtility.DateTimeFromUnixTimestampMillis(_hdfsstatus.modificationTime); }
        }

        public DateTime? AccessDateTime
        {
            get { return LinuxTimeStampUtility.DateTimeFromUnixTimestampMillis(_hdfsstatus.accessTime); }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Type, FullName);
        }
    }
}