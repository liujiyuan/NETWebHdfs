namespace DevZa.aHadoop.Hdfs.Resources
{
    public class WebHdfsAPIConstants
    {

        public class Status
        {
            public static readonly string ListsStatus = "LISTSTATUS";

            public static readonly string GetFileStatus = "GETFILESTATUS";

            public static readonly string CreateFolder = "MKDIRS";

            public static readonly string RemoveFolderOrFile = "DELETE";

            public static readonly string CreateAndWriteToAFile = "CREATE";

            public static readonly string Open = "OPEN";
        }

        public class FileStatusDefine
        {
            public static readonly string Directory = "DIRECTORY";
            public static readonly string File = "FILE";
        }
       
    }
}
