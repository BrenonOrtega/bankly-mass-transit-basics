using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Bankly.MassTransitBasics.Api.Commands;
using Bankly.MassTransitBasics.Api.Dtos;
using Bankly.MassTransitBasics.Contracts.Commands;
using Bankly.MassTransitBasics.Infra;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bankly.MassTransitBasics.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : ControllerBase
    {

        private readonly ILogger<TransferController> _logger;
        private readonly IPublishEndpoint _endpoint;
        private readonly IMapper _mapper;
        private readonly IRepository<CreateTransferCommand> _repo;

        public TransferController(ILogger<TransferController> logger, IPublishEndpoint endpoint, IMapper mapper, IRepository<CreateTransferCommand> repo)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
            
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] TransferCreateDto transfer)
        {
            var command = _mapper.Map<CreateTransferCommand>(transfer);
            
            await Task.WhenAll(
                _endpoint.Publish<ICreateTransferCommand>(command),
                _repo.AddAsync(command.CorrelationId, command)
            );

            return Ok(_mapper.Map<TransferResponseDto>(transfer));
        }
    }
}
