using System;
namespace Bankly.MassTransit.Basics.Contracts.Commands
{
    public interface IMakeTransferCommand
    {
        Guid CorrelationId { get; }
        string Sender { get; }
        string Payer { get; }
        double Amount { get; }
        double TaxAmount { get; }

        bool IsSuccesful { get; set; }

        bool ExecuteTransfer(object makeTransferProcessor);
    }
}