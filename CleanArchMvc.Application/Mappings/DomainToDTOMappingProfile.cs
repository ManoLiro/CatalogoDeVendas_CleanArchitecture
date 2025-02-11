using AutoMapper;

namespace CleanArchMvc.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Domain.Entities.Category, DTOs.CategoryDTO>().ReverseMap();
            CreateMap<Domain.Entities.Product, DTOs.ProductDTO>().ReverseMap();
        }
    }
}
