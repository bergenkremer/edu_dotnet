using AutoMapper;
using MusicTour.Client.DTO.Read;
using MusicTour.Client.Requests.Create;
using MusicTour.Client.Requests.Update;
using MusicTour.Domain.Models;

namespace MusicTour.WebAPI
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DataAccess.Entities.City, Domain.City>();
            this.CreateMap<DataAccess.Entities.Band, Domain.Band>();
            this.CreateMap<DataAccess.Entities.Concert, Domain.Concert>();
            this.CreateMap<Domain.City, CityDTO>();
            this.CreateMap<Domain.Band, BandDTO>();
            this.CreateMap<Domain.Concert, ConcertDTO>();
            
            this.CreateMap<CityCreateDTO, CityUpdateModel>();
            this.CreateMap<CityUpdateDTO, CityUpdateModel>();
            this.CreateMap<CityUpdateModel, DataAccess.Entities.City>();
            
            this.CreateMap<BandCreateDTO, BandUpdateModel>();
            this.CreateMap<BandUpdateDTO, BandUpdateModel>();
            this.CreateMap<BandUpdateModel, DataAccess.Entities.Band>();
            
            this.CreateMap<ConcertCreateDTO, ConcertUpdateModel>();
            this.CreateMap<ConcertUpdateDTO, ConcertUpdateModel>();
            this.CreateMap<ConcertUpdateModel, DataAccess.Entities.Concert>();
        }
    }
}