using System;
using System.Linq;

namespace DevZa.aHadoop.Ultility
{
    public class LinuxPathUtility
    {
        public static string GetAbovePathName(string inputpath)
        {
            CheckPathStartWithSlashorNot(inputpath);
            if (inputpath.Equals("/")) return inputpath;

            var names = inputpath.Split(new char[] { '/' }).ToList();
            if (String.IsNullOrWhiteSpace(names[names.Count - 1]))
            {
                names.RemoveAt(names.Count - 1);
            }
            names.RemoveAt(names.Count - 1);

            if (names.Count == 1) return "/";

            return string.Join("/", names.ToArray());
        }

        public static string GetFolderOrFileName(string inputpath)
        {
            CheckPathStartWithSlashorNot(inputpath);
            if (inputpath.Equals("/")) return inputpath;
            var names = inputpath.Split(new char[] { '/' }).ToList();
            if (String.IsNullOrWhiteSpace(names[names.Count - 1]))
                { return names[names.Count - 2]; }
            return names[names.Count - 1];
        }

        public static void CheckPathStartWithSlashorNot(string inputpath)
        {
            if (string.IsNullOrWhiteSpace(inputpath))
                throw new Exception("input path is Empty");
            if (!(inputpath.Substring(0, 1) == "/"))
                throw new Exception("Path Name Please start with /");
        }
    }
}
