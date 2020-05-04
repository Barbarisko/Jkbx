using Data.Entities;
using Business.Models;
using AutoMapper;
using Data;

namespace Business
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Song, SongModel>().ReverseMap();

            CreateMap<Album, AlbumModel>()
                .ForMember(d => d.Songs, opt => opt.MapFrom(src => src.Songs))
                .ReverseMap();

            CreateMap<Machine, MachineModel>()
                .ForMember(d => d.albums, opt => opt.MapFrom(src => src.albums))
                .ReverseMap();          
         
        }
    }
}
