using Bankly.MassTransitBasics.TransferCreator.Models;
using Bankly.MassTransitBasics.Contracts.Commands;

namespace Bankly.MassTransitBasics.TransferCreator.Profiles
{
    public class AppProfile : AutoMapper.Profile
    {
        public AppProfile()
        {
            CreateMap<ICreateTransferCommand, TransferCreated>();
        }
    }
}