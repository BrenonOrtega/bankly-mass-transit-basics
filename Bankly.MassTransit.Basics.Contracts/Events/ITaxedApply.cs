using System;

namespace Bankly.MassTransit.Basics.Contracts.Events
{
    public interface ITaxedApply
    {
        Guid CorrelationId { get; set; }
        double Amount { get; set; }
        Half Multiplyer { get; set; }
        double TaxValue { get; set; }
    }
}