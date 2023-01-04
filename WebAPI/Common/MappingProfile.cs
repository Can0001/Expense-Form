using AutoMapper;
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
        }
    }
}
