using DevZa.aHadoop.Configuration;
using DevZa.aHadoop.Hdfs.Resources;
using DevZa.aHadoop.Ultility;

namespace DevZa.aHadoop.Hdfs
{
    public class WebHdfsApiHelper
    {
        private static AHadoopConfig AHadoopConfig
        {
            get { return AHadoopConfigurationManager.AHadoopConfig; }
        }

        private static AHadoopUserInfoConfig UserInfoConfig
        {
            get { return AHadoopConfigurationManager.UserInfoConfig; }
        }

        public static string GetBaseUrlString()
        {
            return string.Format("http://{0}:{1}", AHadoopConfig.ActiveHadoopNode.Ip, AHadoopConfig.WebHdfs.NameNodePort);
        }

        public static string GetDataNodeBaseUrlString()
        {
            return string.Format("http://{0}:{1}", AHadoopConfig.FirstDataNode.Ip, AHadoopConfig.WebHdfs.DataNodePort);
        }

        public static string GetNameNodeFullUrlWithApiPrefix(string subpathuri)
        {
            return string.Format("{0}{1}", AHadoopConfig.WebHdfs.ApiPrefix, subpathuri);
        }

        public static string GetOperationAndUserName(string operation)
        {
            return GetOperationAndUserName(operation, UserInfoConfig.User.Id);
        }
        private static string GetOperationAndUserName(string operation, string username)
        {
            return string.Format("op={0}&user.name={1}", operation, username);
        }

        public static string GetListsStatusUri(string path)
        {
            LinuxPathUtility.CheckPathStartWithSlashorNot(path);
            return GetNameNodeFullUrlWithApiPrefix(string.Format("{0}?{1}", path, GetOperationAndUserName(WebHdfsAPIConstants.Status.ListsStatus)));
        }

        public static string GetGetFileStatusUri(string path)
        {
            LinuxPathUtility.CheckPathStartWithSlashorNot(path);
            return GetNameNodeFullUrlWithApiPrefix(string.Format("{0}?{1}", path, GetOperationAndUserName(WebHdfsAPIConstants.Status.GetFileStatus)));
        }

        public static string CreateSubFolderUri(string subpath)
        {
            return
                GetNameNodeFullUrlWithApiPrefix(string.Format("{0}?{1}", subpath,
                    GetOperationAndUserName(WebHdfsAPIConstants.Status.CreateFolder)));
        }

        public static string DeleteSubFolderOrFileUri(string subpath, bool recursive =false)
        {
            return
                GetNameNodeFullUrlWithApiPrefix(string.Format("{0}?{1}&recursive={2} ", subpath,
                    GetOperationAndUserName(WebHdfsAPIConstants.Status.RemoveFolderOrFile),recursive));
        }

        public static string GetCreateFileUri(string path, bool overwrite)
        {
            return
                GetNameNodeFullUrlWithApiPrefix(string.Format("{0}?{1}&overwrite={2}", path,
                    GetOperationAndUserName(WebHdfsAPIConstants.Status.CreateAndWriteToAFile),overwrite));
        }

        public static string OpenFileUri(string fileWithPath)
        {
            return
                GetNameNodeFullUrlWithApiPrefix(string.Format("{0}?{1}", fileWithPath,
                    GetOperationAndUserName(WebHdfsAPIConstants.Status.Open)));
        }
    }
}