using System;

namespace Bankly.MassTransitBasics.Contracts.Events
{
    public interface ITaxApplied
    {
        Guid CorrelationId { get; set; }
        double Amount { get; set; }
        double Multiplyer { get; set; }
        double TaxValue { get; set; }
    }
}