using AutoMapper;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;

namespace WebAPI.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ReceiptsDto, Receipt>();
            CreateMap<VoucherDto, Voucher>();
            CreateMap<ReportDto, Report>();
            CreateMap<OperationClaimsDto, OperationClaim>();
            CreateMap<UserOperationClaimDto, UserOperationClaim>();
        }
    }
}
