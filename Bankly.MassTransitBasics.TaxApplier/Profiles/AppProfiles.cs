using AutoMapper;
using Bankly.MassTransitBasics.Contracts.Commands;
using Bankly.MassTransitBasics.TaxApplier.Models;

namespace Bankly.MassTransitBasics.TaxApplier.Profiles
{
    public class AppProfiles : Profile
    {
        public AppProfiles()
        {
            CreateMap<IApplyTaxCommand, TaxedTransfer>();
        }
    }
}