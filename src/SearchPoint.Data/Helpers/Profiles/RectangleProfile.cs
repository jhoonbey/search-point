using AutoMapper;
using SearchPoint.Data.Dto;
using SearchPoint.Data.Entities;

namespace SearchPoint.Data.Helpers.Profiles
{
    public class RectangleProfile : Profile
    {
        public RectangleProfile()
        {
            CreateMap<Rectangle, RectangleDto>().ReverseMap();
        }
    }
}