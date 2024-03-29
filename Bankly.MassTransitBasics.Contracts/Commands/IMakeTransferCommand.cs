using System;
namespace Bankly.MassTransitBasics.Contracts.Commands
{
    public interface IMakeTransferCommand
    {
        Guid CorrelationId { get; }
        string Sender { get; }
        string Receiver { get; }
        double Amount { get; }
        double TaxAmount { get; }

        bool IsSuccesful { get; set; }

        bool ExecuteTransfer(object makeTransferProcessor);
    }
}