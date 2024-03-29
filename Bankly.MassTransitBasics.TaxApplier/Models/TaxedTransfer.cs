using System;
using Bankly.MassTransitBasics.Contracts.Events;

namespace Bankly.MassTransitBasics.TaxApplier.Models
{
    public class TaxedTransfer : ITaxApplied
    {
        public Guid CorrelationId { get; set; }
        public double Amount { get; set; }
        public double Multiplyer { get; set; }
        public double TaxValue { get; set; }

        public void Apply() 
        {
            Multiplyer = Amount >= 20 ? 0.05 : 0.025;
            TaxValue = Amount * Multiplyer;
            Amount -= TaxValue;
        }
    }
}