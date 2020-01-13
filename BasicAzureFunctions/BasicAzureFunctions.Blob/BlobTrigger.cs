using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace BasicAzureFunctions
{
    public static class BlobTrigger
    {
        [FunctionName("BlobTrigger")]
        public static void Run([BlobTrigger("samples-workitems/{name}", Connection = "myConnectionString")] Stream myBlob,
        [Blob("output/{name}",FileAccess.Write,Connection = "myOutputConnectionString")] Stream outputBlob, 
        string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

        }
    }
}
