using System;

namespace Accounting.RabbitMQ.Api.Models
{
    public class FisModel
    {
        public string TransactionObjectId {get; set;}
        public string TransactionType { get; set; }
        public string Amount { get; set; }
    }
}
