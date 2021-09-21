using System;

namespace Bankly.MassTransit.Basics.Contracts.Events
{
    public interface ITranferCompleted
    {
        Guid CorrelationId { get; set; }
        bool IsSuccesful { get; set; }
    }
}