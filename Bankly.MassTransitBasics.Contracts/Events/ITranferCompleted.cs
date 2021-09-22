using System;

namespace Bankly.MassTransitBasics.Contracts.Events
{
    public interface ITranferCompleted
    {
        Guid CorrelationId { get; set; }
        bool IsSuccesful { get; set; }
    }
}