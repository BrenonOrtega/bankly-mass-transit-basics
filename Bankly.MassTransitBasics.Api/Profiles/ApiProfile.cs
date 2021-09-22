using AutoMapper;
using Bankly.MassTransitBasics.Api.Commands;
using Bankly.MassTransitBasics.Api.Dtos;

namespace Bankly.MassTransitBasics.Api.Profiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<CreateTransferCommand, TransferCreateDto>();

            CreateMap<TransferCreateDto, TransferResponseDto>();
        }
    }
}