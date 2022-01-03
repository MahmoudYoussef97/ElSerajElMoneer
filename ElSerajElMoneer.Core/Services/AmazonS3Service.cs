using System;
using System.Net;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.S3.Util;
using Microsoft.Extensions.Logging;

namespace ElSerajElMoneer.Core.Services
{
    public class AmazonS3Service
    {
        private readonly ILogger<AmazonS3Service> _logger;
        private readonly IAmazonS3 _amazonS3Client;
        private readonly TransferUtility _transferUtility;

        public AmazonS3Service(ILogger<AmazonS3Service> logger,
            IAmazonS3 amazonS3Client, TransferUtility transferUtility)
        {
            _logger = logger;
            _amazonS3Client = amazonS3Client;
            _transferUtility = transferUtility;
        }
        public async Task<bool> CreateBucketAsync(string bucketName)
        {
            try
            {
                _logger.LogInformation("Creating Amazon S3 bucket...");
                var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(_amazonS3Client, bucketName);
                if (bucketExists)
                {
                    _logger.LogInformation($"Amazon S3 bucket with name '{bucketName}' already exists");
                    return false;
                }

                var bucketRequest = new PutBucketRequest()
                {
                    BucketName = bucketName,
                    UseClientRegion = true
                };

                var response = await _amazonS3Client.PutBucketAsync(bucketRequest);

                if (response.HttpStatusCode != HttpStatusCode.OK)
                {
                    _logger.LogError("Something went wrong while creating AWS S3 bucket.", response);
                    return false;
                }

                _logger.LogInformation("Amazon S3 bucket created successfully");
                return true;
            }
            catch (AmazonS3Exception ex)
            {
                _logger.LogError("Something went wrong", ex);
                throw;
            }
        }
    }
}
