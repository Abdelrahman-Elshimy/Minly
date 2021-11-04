using AutoMapper;
using Minly.Core.DTOs;
using Minly.Data;

namespace Minly.Core.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
            CreateMap<Hotel, UpdateHotelDTO>().ReverseMap();
            CreateMap<ApiUser, UserDTO>().ReverseMap();
            CreateMap<Star, StarDTO>().ReverseMap();
            CreateMap<Star, OnlyStarDTO>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<Service, GETServiceDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, GETCategoryDTO>().ReverseMap();
            CreateMap<Event, EventDTO>().ReverseMap();
            CreateMap<EventMembership, EventMembershipBasic>().ReverseMap();
            CreateMap<EventMembership, EventMembershipDTO>().ReverseMap();
            CreateMap<EventMembership, EventMembershipWithoutInsideDataDTO>().ReverseMap();
            CreateMap<EventType, EventTypeBasicDTO>().ReverseMap();
            CreateMap<EventType, EventTypeDTO>().ReverseMap();
            CreateMap<EventVideo, EventVidoDTO>().ReverseMap();
            CreateMap<EventRate, CreateEventRate>().ReverseMap();
            CreateMap<EventRate, EventRateDTO>().ReverseMap();
            CreateMap<StarRate, StarRateDTO>().ReverseMap();
            CreateMap<StarRate, CreateStarRate>().ReverseMap();
            CreateMap<RequestEvent, RequestEventDTO>().ReverseMap();
            CreateMap<RequestEvent, CreateRequestEventDTO>().ReverseMap();
            CreateMap<RequestStar, RequestStarDTO>().ReverseMap();
            CreateMap<RequestStar, CreateRequestStarDTO>().ReverseMap();
        }
    }
}
