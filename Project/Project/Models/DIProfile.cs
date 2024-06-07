using AutoMapper;
using Project.Models.DTO;

namespace Project.Models
{
    public class DIProfile : Profile
    {
        public DIProfile()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<DonorDto, Donor>();
            CreateMap<PresentDto, Present>();
        }
    }
}
