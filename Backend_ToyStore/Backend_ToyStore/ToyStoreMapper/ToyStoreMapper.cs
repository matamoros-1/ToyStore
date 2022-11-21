using AutoMapper;
using Backend_ToyStore.Models;
using Backend_ToyStore.Models.Dtos;
using Backend_ToyStore.Models.Dtos.JugueteDtos;

namespace Backend_ToyStore.ToysToreMapper
{
    public class ToyStoreMapper : Profile
    {
        public ToyStoreMapper() 
        {
            CreateMap<Juguete, JugueteShowDto>().ReverseMap();
            CreateMap<Juguete, JugueteAddDto>().ReverseMap();
            CreateMap<Juguete, JugueteUpdateDto>().ReverseMap();
        }
    }
}
