using System;

namespace Bankly.MassTransitBasics.Contracts.Events
{
    public interface ITaxedApply
    {
        Guid CorrelationId { get; set; }
        double Amount { get; set; }
        Half Multiplyer { get; set; }
        double TaxValue { get; set; }
    }
}