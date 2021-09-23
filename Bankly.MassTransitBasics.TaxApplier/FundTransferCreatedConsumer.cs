using System;
using System.Threading.Tasks;
using AutoMapper;
using Bankly.MassTransitBasics.Contracts.Events;
using Bankly.MassTransitBasics.Infra;
using Bankly.MassTransitBasics.TaxApplier.Models;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Bankly.MassTransitBasics.TaxApplier
{
    public class FundTransferCreatedConsumer : IConsumer<ITransferCreated>
    {
        private readonly ILogger<FundTransferCreatedConsumer> _logger;
        private readonly IRepository<TaxedTransfer> _repo;
        private readonly IMapper _mapper;

        public FundTransferCreatedConsumer(ILogger<FundTransferCreatedConsumer> logger, IRepository<TaxedTransfer> repo, IMapper mapper)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }

        public Task Consume(ConsumeContext<ITransferCreated> context)
        {
            _logger.LogInformation("Consuming message {0}", context.Message);
            var taxCommand = context.Message;
            var taxedTransfer = _mapper.Map<TaxedTransfer>(taxCommand);

            taxedTransfer.Apply();

            return Task.WhenAll(_repo.AddAsync(
                taxedTransfer.CorrelationId, taxedTransfer),
                context.Publish<ITaxApplied>(taxedTransfer));
        }
    }
}