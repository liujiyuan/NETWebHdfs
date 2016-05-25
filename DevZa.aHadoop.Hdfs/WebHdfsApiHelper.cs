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

        private static AHadoopUserInfoConfig UserInfoConfig => AHadoopConfigurationManager.UserInfoConfig;

        public static string GetBaseUrlString() => $"http://{AHadoopConfig.ActiveHadoopNode.Ip}:{AHadoopConfig.WebHdfs.NameNodePort}";

        public static string GetDataNodeBaseUrlString() => $"http://{AHadoopConfig.FirstDataNode.Ip}:{AHadoopConfig.WebHdfs.DataNodePort}";

        public static string GetNameNodeFullUrlWithApiPrefix(string subpathuri) => $"{AHadoopConfig.WebHdfs.ApiPrefix}{subpathuri}";

        public static string GetOperationAndUserName(string operation)
        {
            return GetOperationAndUserName(operation, UserInfoConfig.User.Id);
        }
        private static string GetOperationAndUserName(string operation, string username) => $"op={operation}&user.name={username}";

        public static string GetListsStatusUri(string path)
        {
            LinuxPathUtility.CheckPathStartWithSlashorNot(path);
            return GetNameNodeFullUrlWithApiPrefix(
                $"{path}?{GetOperationAndUserName(WebHdfsAPIConstants.Status.ListsStatus)}");
        }

        public static string GetGetFileStatusUri(string path)
        {
            LinuxPathUtility.CheckPathStartWithSlashorNot(path);
            return GetNameNodeFullUrlWithApiPrefix(
                $"{path}?{GetOperationAndUserName(WebHdfsAPIConstants.Status.GetFileStatus)}");
        }

        public static string CreateSubFolderUri(string subpath)
        {
            return
                GetNameNodeFullUrlWithApiPrefix(
                    $"{subpath}?{GetOperationAndUserName(WebHdfsAPIConstants.Status.CreateFolder)}");
        }

        public static string DeleteSubFolderOrFileUri(string subpath, bool recursive =false)
        {
            return
                GetNameNodeFullUrlWithApiPrefix(string.Format("{0}?{1}&recursive={2} ", subpath,
                    GetOperationAndUserName(WebHdfsAPIConstants.Status.RemoveFolderOrFile),recursive));
        }

        public static string GetCreateFileUri(string path, bool overwrite) => GetNameNodeFullUrlWithApiPrefix(
            $"{path}?{GetOperationAndUserName(WebHdfsAPIConstants.Status.CreateAndWriteToAFile)}&overwrite={overwrite}");

        public static string OpenFileUri(string fileWithPath) => GetNameNodeFullUrlWithApiPrefix(
            $"{fileWithPath}?{GetOperationAndUserName(WebHdfsAPIConstants.Status.Open)}");
    }
}