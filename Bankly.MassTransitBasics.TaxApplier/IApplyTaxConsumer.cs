using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MassTransit;
using Bankly.MassTransitBasics.Contracts.Commands;
using Bankly.MassTransitBasics.Infra;
using Bankly.MassTransitBasics.TaxApplier.Models;
using AutoMapper;
using Bankly.MassTransitBasics.Contracts.Events;

namespace Bankly.MassTransitBasics.TaxApplier
{
    public class IApplyTaxConsumer : IConsumer<IApplyTaxCommand>
    {
        private readonly ILogger<IApplyTaxConsumer> _logger;
        private readonly IRepository<ITaxApplied> _repo;
        private readonly IMapper _mapper;

        public IApplyTaxConsumer(ILogger<IApplyTaxConsumer> logger, IRepository<ITaxApplied> repo, IMapper mapper)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));;
        }

        public Task Consume(ConsumeContext<IApplyTaxCommand> context)
        {
            _logger.LogInformation("Consuming message {0}", context.Message);
            var taxCommand = context.Message;
            var taxedTransfer = _mapper.Map<TaxedTransfer>(taxCommand);

            return Task.WhenAll(_repo.AddAsync(
                taxedTransfer.CorrelationId, taxedTransfer),
                context.Publish(taxedTransfer));
        }
    }
}
