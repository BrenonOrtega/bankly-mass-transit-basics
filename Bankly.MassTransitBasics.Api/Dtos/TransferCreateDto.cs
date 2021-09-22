using System;

namespace Bankly.MassTransitBasics.Api.Dtos
{
    public class TransferCreateDto
    {
        public Guid CorrelationId { get; set; } = Guid.NewGuid();
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime CreatedAt { get; } = DateTime.Now;
        public double Amount { get; set; }
    }
}