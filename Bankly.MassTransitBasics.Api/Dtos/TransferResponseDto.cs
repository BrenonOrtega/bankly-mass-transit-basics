using System;
using Bankly.MassTransitBasics.Contracts.Enum;

namespace Bankly.MassTransitBasics.Api.Dtos
{
    public class TransferResponseDto
    {
        public Guid CorrelationId { get; set; } 
        public DateTime CreatedAt { get; set; } 
        private TransferStatus _status = TransferStatus.CREATED;
        private string Status { get => _status.ToString(); set => _status = value.ToStatus(); }

    }
}