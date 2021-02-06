
using Microsoft.AspNetCore.Mvc;
using Accounting.RabbitMQ.Api.Services;
using Accounting.RabbitMQ.Api.Models;

namespace Accounting.RabbitMQ.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddQueueController : ControllerBase
    {
        [HttpPost]
        public string AddQueue(FisModel fisModel)
        {
             RabbitMQService rabbitMq = new RabbitMQService(fisModel);
             
             return rabbitMq.Post();
        }

    }
}
