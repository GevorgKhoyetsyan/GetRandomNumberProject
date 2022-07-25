using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GetRandomNumberProject
{
    public static class GetRandomNumberFunction
    {
        [FunctionName("GetRandomNumberFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            int randomNumber = GetRandomNumber(1, 10);

            return new OkObjectResult(randomNumber);
        }
        static int GetRandomNumber(int min, int max)
        {
            Random random = new Random();

            return random.Next(min, max + 1);
        }
    }
}
