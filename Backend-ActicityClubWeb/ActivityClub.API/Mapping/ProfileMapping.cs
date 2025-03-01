using ActivityClub.Core.DTOs;
using ActivityClub.Core.Models;
using AutoMapper;
using ActivityClub.API.Requests;

namespace ActivityClub.API.Mapping;
public class ProfileMapping : Profile
{
    public ProfileMapping()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Admin, AdminDTO>().ReverseMap();
        CreateMap<Guide, GuideDTO>().ReverseMap();
        CreateMap<Member, MemberDTO>().ReverseMap();
        CreateMap<Event, EventDTO>().ReverseMap();
        CreateMap<EventMember, EventMemberDTO>().ReverseMap();
        CreateMap<EventGuide, EventGuideDTO>().ReverseMap();
        //CreateMap<LoginRequest, User>();
        CreateMap<LoginRequest, User>()
            .ForMember(dest => dest.Userid, opt => opt.MapFrom(src => src.Userid))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

    }
}

