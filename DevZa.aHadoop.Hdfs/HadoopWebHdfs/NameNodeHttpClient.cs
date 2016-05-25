using System;
using System.Net.Http;
using System.Threading.Tasks;
using DevZa.Logger;

namespace DevZa.aHadoop.Hdfs.HadoopWebHdfs
{
    public class NameNodeHttpClient : HttpClient, INameNodeHttpClient
    {
        private static IZaLogger _log = LoggerFactory.GetLogger<NameNodeHttpClient>();

        public NameNodeHttpClient()
        {
            this.BaseAddress = new Uri(WebHdfsApiHelper.GetBaseUrlString());
            this.Timeout = TimeSpan.FromMinutes(5);
        }


        private async Task<object> GetWebHdfsApiAsync<T>(string uri)
        {
            var response = await GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<T>();
                return result;
            }
            if (!response.IsSuccessStatusCode)
            {
                LogErrorRespone(response, uri);
            }
            return null;
        }

        private async Task<object> PutWebHdfsApiAsync<T>(string uri, HttpContent content)
        {
            var response = await PutAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<T>();
                return result;
            }
            if (!response.IsSuccessStatusCode)
            {
                LogErrorRespone(response, uri);
            }
            return null;
        }

        private async void LogErrorRespone(HttpResponseMessage response, string uri)
        {
            var result = await response.Content.ReadAsAsync<RemoteExceptionResult>();
            _log.ErrorFormat("Error Calling Web Api: {0}, exception:{1}, javaclass:{2}, message:{3}", uri, result.RemoteException.exception, result.RemoteException.javaClassName, result.RemoteException.message);
        }

        public async Task<WebHdfsFileStatus> GetWebHdfsGetFileStatus(string fileOrPath)
        {

            var result = await GetWebHdfsApiAsync<WebHdfsFileStatus>(WebHdfsApiHelper.GetGetFileStatusUri(fileOrPath));
            return (WebHdfsFileStatus) result;
        }

        public async Task<byte[]> WebHdfsOpenFile(string fileWithPath)
        {
            var uri = WebHdfsApiHelper.OpenFileUri(fileWithPath);
            var response = await GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsByteArrayAsync();
                return result;
            }
            if (!response.IsSuccessStatusCode)
            {
                LogErrorRespone(response, uri);
            }
            return null;
        }

        public async Task<WebHdfsListsStatus> GetWebHdfsListStatus(string fileOrPath)
        {
            var result = await GetWebHdfsApiAsync<WebHdfsListsStatus>(WebHdfsApiHelper.GetListsStatusUri(fileOrPath));
            return (WebHdfsListsStatus)result;
        }



        public async Task<bool> CreateSubFolder(string subpath)
        {
            var response = await PutAsync(WebHdfsApiHelper.CreateSubFolderUri(subpath),new StringContent(""));
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<WebHdfsBooleanResult>();
                return result.boolean;
            }
            if (!response.IsSuccessStatusCode)
            {
                LogErrorRespone(response, WebHdfsApiHelper.CreateSubFolderUri(subpath));
            }
            return false;
        }



        public async Task<bool> DeleteSubFolderOrFile(string subpath,bool recursive=false)
        {
            var response = await DeleteAsync(WebHdfsApiHelper.DeleteSubFolderOrFileUri(subpath,recursive));
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<WebHdfsBooleanResult>();
                return result.boolean;
            }
            if (!response.IsSuccessStatusCode)
            {
                LogErrorRespone(response, WebHdfsApiHelper.DeleteSubFolderOrFileUri(subpath,recursive));
            }
            return false;
        }


        public async Task<bool> PutLocalFile(string filenameWithPath,byte[] bytes,bool overwrite=true)
        { 
            HttpContent content = new ByteArrayContent(bytes);
            var response = await PutAsync(WebHdfsApiHelper.GetCreateFileUri(filenameWithPath,overwrite), content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            if (!response.IsSuccessStatusCode)
            {
                LogErrorRespone(response, WebHdfsApiHelper.GetCreateFileUri(filenameWithPath, overwrite));
            }
            return false;
        }
    }

    
}