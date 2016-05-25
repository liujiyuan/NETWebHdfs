# NETWebHdfs
draft version call web hdfs for .net

提供給剛好有要應急使用的人

使用前前置作業

1. 需copy aHadoop.config, DevZa.config 到你的專案目錄

2. 參考 DevZa.aHdoop.Hdfs,  DevZa.aHdoop.Core, DevZa.Core

3. 修改aHadoop.Config 檔案  (因為公司開發的習慣，有一些資料寫在Config 檔，而沒有在建構子提供)

nameNodes 的部分， 主要把 type = "Active" 的 ip 設定好
<nameNodes>
      <add name="yourhost" ip="yourip" type="Active" />
      <add name="yourhost2" ip="yourip2" type="StandBy" />
    </nameNodes>

以及帳號的部分 (我相信台灣大部分的webhdfs 的Security 其實是沒有安全性的，因此大都放在隔絕的環境使用........)

 <aHadoopUserInfoSecurity>
    <user id="hadoop" password="hadoop" />
  </aHadoopUserInfoSecurity>
  




下面是 Sample Code (也可以看一下Unit Test 的程式碼)

1. 取得 目錄 資訊

IHadoopHdfsService manager = new HadoopHdfsManager();

var info = manager.GetDirectoryInformation("/tmp").Result;

2. 取得檔案資訊

var manager = new HadoopHdfsManager();

 var status = manager.GetWebHdfsGetFileStatus("/user/history/testfile").Result;

3. 建立目錄

IHadoopHdfsService manager = new HadoopHdfsManager();

var info = manager.GetDirectoryInformation("/tmp").Result;

info.CreateSubFolder("NewFolder");

4. 上傳本地檔案

IHadoopHdfsService manager = new HadoopHdfsManager();

var info = manager.GetDirectoryInformation("/tmp").Result;

var result = info.PutFileFromLocal(@"D:\temp\Sample.txt");

5. 下載hdfs檔案

IHadoopHdfsService manager = new HadoopHdfsManager();

var info = manager.GetDirectoryInformation("/tmp").Result;

info.DownloadFile("9F.pptx");

6. 刪除檔案或目錄

IHadoopHdfsService manager = new HadoopHdfsManager(new WebHdfsRestfulConnection("impala", ""));

var info = manager.GetDirectoryInformation("/tmp/impala/QueryAndInsert").Result;

var result = manager.RemoveSubFolderOrFile(info, "QueryAndInsertP100000", true);



目前沒有將所有api 介面實作出來

只有針對有需要的部分開發

如果有興趣的人，可以參考hadoop的api 手冊

https://hadoop.apache.org/docs/current/hadoop-project-dist/hadoop-hdfs/WebHDFS.html


