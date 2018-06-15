using AutoMapper;
using SharpTrooper.Entities;
using StarwarsApi.Controllers;

namespace StarwarsApi
{
    public class Automapper: Profile
    {
        public static void Init()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new Automapper()));
        }

        public Automapper()
        {
            this.CreateMap<People, Person>()
                .ForMember(src=>src.SkinColor, cfg=>cfg.MapFrom(element=> element.skin_color));
        }
    }
}
