using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MassTransit;
using Bankly.MassTransitBasics.Contracts.Commands;
using AutoMapper;
using Bankly.MassTransitBasics.TransferCreator.Models;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Bankly.MassTransitBasics.Contracts.Events;
using Bankly.MassTransitBasics.Infra;

namespace Bankly.MassTransitBasics.TransferCreator
{
    public class ICreateTransferConsumer : IConsumer<ICreateTransferCommand>
    {
        private readonly ILogger<ICreateTransferConsumer> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<TransferCreated> _repo;

        public ICreateTransferConsumer(ILogger<ICreateTransferConsumer> logger, IMapper mapper, IRepository<TransferCreated> repo)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public Task Consume(ConsumeContext<ICreateTransferCommand> context)
        {
            _logger.LogInformation("Consuming {0} command received at {1}", nameof(ICreateTransferCommand), DateTime.Now);
            var command = _mapper.Map<TransferCreated>(context.Message);
            
            return Task.WhenAll(
                context.Publish<ITransferCreated>(command), 
                _repo.AddAsync(command.CorrelationId, command)
            );
        }
    }
}
