using System;

namespace Bankly.MassTransitBasics.Contracts.Events
{
    public interface ITransferCreated
    {
        Guid CorrelationId { get; set; }
        string Sender { get; set; }
        string Receiver { get; set; }
        double Amount { get; set; }
        DateTime CreatedAt { get; set; }
    }
}