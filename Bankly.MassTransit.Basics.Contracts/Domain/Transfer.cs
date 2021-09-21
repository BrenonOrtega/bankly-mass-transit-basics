using System;
using Bankly.MassTransitBasics.Contracts.Enum;

namespace Bankly.MassTransitBasics.Contracts.Domain
{
    public class Transfer
    {
        public Guid CorrelationId { get; set; }
        public string sender { get; set; }
        public string Payer { get; set; }
        public double Amount { get; set; }
        public double TaxAmount { get; set; }
        public Half TaxMultiplyer { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public TransferStatus Status { get; set; }
        public bool Finished { get; set; }
    }
}