using Aranda.Domain.Dto;
using Aranda.Domain.Models;
using AutoMapper;

namespace Aranda.Infraestructure.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Catalogue, CatalogueDto>();
            CreateMap<CatalogueDto, Catalogue>();


            CreateMap<Catalogue, Dto>();
            CreateMap<Dto, Catalogue>();


            
        }
    }
}
