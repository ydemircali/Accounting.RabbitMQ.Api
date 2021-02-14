using Microsoft.AspNetCore.Mvc;
using Accounting.RabbitMQ.Api.Services;
using Accounting.RabbitMQ.Api.Models;
using System;

namespace Accounting.RabbitMQ.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class QueueApiController : ControllerBase
    {
        [HttpPost]
        public string AddAccTransaction(FisModel fisModel)
        {
             RabbitMQService rabbitMq = new RabbitMQService(fisModel);
             
             return rabbitMq.Post();
        }

        [HttpPost]
        public string BulkAccTransaction(int count = 100)
        {
            Random rnd = new Random();


            for (int i = 0; i < count; i++)
            {
                var fisModel = new FisModel();
                fisModel.TransactionType = "Maaş";
                fisModel.TransactionObjectId = rnd.Next(100, 9999).ToString();
                fisModel.Amount = rnd.Next(3000, 9999).ToString();

                 RabbitMQService rabbitMq = new RabbitMQService(fisModel);
                rabbitMq.Post();
            }
           
             return "Tamamlandı";
        }
    }
}
