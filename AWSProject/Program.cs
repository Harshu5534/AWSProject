using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.VisualBasic;

namespace AWSProject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Constants constants = new Constants();
                var credentials = new BasicAWSCredentials(constants.UID, constants.secret);
                var s3Client = new AmazonS3Client(constants.UID, constants.secret, Amazon.RegionEndpoint.USEast1);
                //Create Bucket
                //var response = await s3Client.PutBucketAsync(new PutBucketRequest
                //{
                //    BucketName = "harshal-newbucketform"
                //});
                //Console.WriteLine(response.HttpStatusCode);

                //Delete Bucket
                var response = await s3Client.DeleteBucketAsync(new DeleteBucketRequest
                {
                    BucketName = "harshal-newbucketform"
                });
                Console.WriteLine(response.HttpStatusCode);

                //List of Bucket
                //var buckets = await s3Client.ListBucketsAsync();
                //Console.WriteLine(String.Join(",", buckets.Buckets.Select(x => x.BucketName)));

                //foreach (var bucket in buckets.Buckets)
                //{
                //    var objects = await s3Client.ListObjectsAsync(bucket.BucketName);
                //    if (objects != null)
                //        Console.WriteLine($"For bucket{bucket.BucketName},files: {String.Join(",", objects.S3Objects.Select(x => x.Key))}");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        //public void UploadFile()
        //{
        //    Constants constants = new Constants();
        //    var s3Client = new AmazonS3Client(constants.UID, constants.secret, Amazon.RegionEndpoint.USEast1);
        //    var fileTransferUtility = new TransferUtility(s3Client);
        //    string filePath = "C:\\Users\\Dell\\Pictures\\Krishna.jpg";
        //    //FileStream fs=File.Open(filePath,FileMode.Open);
        //    try
        //    {
        //        var fileTransferUtilityRequest = new TransferUtilityUploadRequest
        //        {
        //            BucketName = "harshal-newbucket",
        //            FilePath = filePath,
        //            StorageClass = S3StorageClass.StandardInfrequentAccess,
        //            PartSize = 27,
        //            Key = "Krishna.jpg",
        //            CannedACL = S3CannedACL.PublicRead
        //        };
        //        fileTransferUtility.UploadAsync(fileTransferUtilityRequest).GetAwaiter().GetResult();
        //        Console.WriteLine("File Uploaded Successfully.");
        //        //fileTransferUtility.Upload(filePath, "harshal-newbucket", "Sampleemail.txt");
        //        //fileTransferUtility.Dispose();
        //    }
        //    catch (AmazonS3Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}
        //static void Main(string[] args)
        //{
        //    Program program = new Program();
        //    program.UploadFile();
        //}
    }
}