using System;
using Bankly.MassTransitBasics.Contracts.Commands;

namespace Bankly.MassTransitBasics.Api.Commands
{
    public class CreateTransferCommand : ICreateTransferCommand
    {
        public Guid CorrelationId { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}