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

namespace Bankly.MassTransitBasics.TransferCreator
{
    public class Worker : IConsumer<ICreateTransferCommand>
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMapper _mapper;

        public Worker(ILogger<Worker> logger, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task Consume(ConsumeContext<ICreateTransferCommand> context)
        {
            _logger.LogInformation("Consuming {0} command received at {1}", nameof(ICreateTransferCommand), DateTime.Now);
            
            return context.Send(_mapper.Map<TransferCreated>(context.Message));
        }
    }
}
