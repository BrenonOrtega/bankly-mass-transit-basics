using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bankly.MassTransitBasics.Contracts.Events;
using Bankly.MassTransitBasics.Contracts.Domain;
using Bankly.MassTransitBasics.Infra;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace Bankly.MassTransitBasics.OperationalTransfer
{
    public class TaxedTransferConsumer : IConsumer<ITaxApplied>
    {
        private readonly ILogger<TaxedTransferConsumer> _logger;
        private readonly IRepository<Transfer> _repo;
        private readonly IMapper _mapper;

        public TaxedTransferConsumer(ILogger<TaxedTransferConsumer> logger, IRepository<Transfer> repo, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Consume(ConsumeContext<ITaxApplied> context)
        {
            _logger.LogInformation("TaxedTransferConsumer running at: {time}\n Consumed Message: {message}", DateTimeOffset.Now, context.Message);
            return Task.Delay(1000);
        }
    }
}
