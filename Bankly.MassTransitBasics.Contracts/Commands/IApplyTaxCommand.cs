using System;

namespace Bankly.MassTransitBasics.Contracts.Commands
{
    public interface IApplyTaxCommand
    {
        Guid CorrelationId { get; set; }
        double Amount { get; set; }
    }
}