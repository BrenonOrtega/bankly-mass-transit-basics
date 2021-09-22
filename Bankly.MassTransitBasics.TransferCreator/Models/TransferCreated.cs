using System;
using Bankly.MassTransitBasics.Contracts.Events;

namespace Bankly.MassTransitBasics.TransferCreator.Models
{
    internal class TransferCreated : ITransferCreated
    {
        public Guid CorrelationId { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}