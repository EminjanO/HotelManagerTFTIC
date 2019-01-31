using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace HotelManager.Help
{
    public static class BlobStockage
    {
        public static string GetLogs()
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=hotelmanagerblob;AccountKey=0rIspWPXwm7U22uvlHZshW6mHeJKLw1W5Tu3OQbi8jUasSRVju61eU0teHvNHwtzuGW68vmtRH9uE/rlhoqAnQ==;EndpointSuffix=core.windows.net";
                                      
            string file = "appendBlop.txt";
            string logs = "No Log or file not found";

            CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);

            if (account == null) return logs;

            CloudBlobClient client = account.CreateCloudBlobClient();

            if (client == null) return logs;

            CloudBlobContainer container = client.GetContainerReference("hotelmanagerlog");

            if (!container.Exists()) container.Create();

            CloudAppendBlob blob = container.GetAppendBlobReference(file);

            if (!blob.Exists()) return logs;

            logs = blob.DownloadText();

            return logs;
        }
        public static void WriteLogs(string log)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=hotelmanagerblob;AccountKey=0rIspWPXwm7U22uvlHZshW6mHeJKLw1W5Tu3OQbi8jUasSRVju61eU0teHvNHwtzuGW68vmtRH9uE/rlhoqAnQ==;EndpointSuffix=core.windows.net";
            string file = "appendBlop.txt";

            CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);

            if (account == null) return;

            CloudBlobClient client = account.CreateCloudBlobClient();

            if (client == null) return;

            CloudBlobContainer container = client.GetContainerReference("hotelmanagerlog");

            try
            {
                container.CreateIfNotExists();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }


            CloudAppendBlob blob = container.GetAppendBlobReference(file);

            if (!blob.Exists()) blob.CreateOrReplace();

            blob.AppendText($"{log} {Environment.NewLine}");
        }
        public static void WritePhoto(string disName, string completedPath)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=hotelmanagerblob;AccountKey=0rIspWPXwm7U22uvlHZshW6mHeJKLw1W5Tu3OQbi8jUasSRVju61eU0teHvNHwtzuGW68vmtRH9uE/rlhoqAnQ==;EndpointSuffix=core.windows.net";
            string file = "appendBlop.txt";

            CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);

            if (account == null) return;

            CloudBlobClient client = account.CreateCloudBlobClient();

            if (client == null) return;

            CloudBlobContainer container = client.GetContainerReference("hotelmanagerphoto");

            container.CreateIfNotExists();

            CloudBlockBlob blob = container.GetBlockBlobReference(disName);

            if (blob.Exists()) blob.Delete();
            blob.UploadFromFile(completedPath);
        }

        public static  List<IListBlobItem> GetBlobPhoto(string blobcontainer)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=hotelmanagerblob;AccountKey=0rIspWPXwm7U22uvlHZshW6mHeJKLw1W5Tu3OQbi8jUasSRVju61eU0teHvNHwtzuGW68vmtRH9uE/rlhoqAnQ==;EndpointSuffix=core.windows.net";

            CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);

            CloudBlobClient client = account.CreateCloudBlobClient();

            CloudBlobContainer container = client.GetContainerReference(blobcontainer);

           container.CreateIfNotExistsAsync();

            container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            BlobContinuationToken continuationToken = null;

            List<IListBlobItem> blobItems = new List<IListBlobItem>();


            blobItems = container.ListBlobs().ToList();

            return blobItems;
        }
    }
}