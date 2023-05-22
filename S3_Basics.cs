using Amazon.S3;
using Amazon.S3.Model;

namespace S3_BasicsScenario
{
    public class S3_Basics
    {
        public static async Task Main()
        {
            IAmazonS3 client = new AmazonS3Client();
            string bucketName = string.Empty;

            Console.Write("Please enter a name for the new bucket: ");
            bucketName = Console.ReadLine();

            var success = await CreateBucket(client, bucketName);
            if (success)
            {
                Console.WriteLine($"Successfully created bucket: {bucketName}.\n");
            }
            else
            {
                Console.WriteLine($"Could not create bucket: {bucketName}.\n");
            }
        }

        public static async Task<bool> CreateBucket(IAmazonS3 client, string bucketName)
        {
            try
            {
                var request = new PutBucketRequest
                {
                    BucketName = bucketName,
                    UseClientRegion = true,
                };

                var response = await client.PutBucketAsync(request);
                return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"Error creating bucket: '{ex.Message}'");
                return false;
            }
        }
    }
}
