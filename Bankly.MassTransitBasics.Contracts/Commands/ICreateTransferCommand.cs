using System;

namespace Bankly.MassTransitBasics.Contracts.Commands
{
    public interface ICreateTransferCommand
    {
        Guid CorrelationId { get; set; }
        string Sender { get; set; }
        string Receiver { get; set; }
        double Amount { get; set; }
        DateTime CreatedAt { get; set; }
    }
}