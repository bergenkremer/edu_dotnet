using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicTour.DataAccess.Context;
using MusicTour.DataAccess.Contracts;
using MusicTour.Domain;
using MusicTour.Domain.Contracts;
using MusicTour.Domain.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace MusicTour.DataAccess.Implementations
{
    public class CityDataAccess : ICityDataAccess
    {
        private MusicTourContext Context { get; }
        private IMapper Mapper { get; }

        public CityDataAccess(MusicTourContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<City> InsertAsync(CityUpdateModel city)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.City>(city));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<City>(result.Entity);
        }

        public async Task<IEnumerable<City>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<City>>(
                await this.Context.City.ToListAsync());

        }

        public async Task<City> GetAsync(ICityIdentity city)
        {
            var result = await this.Get(city);

            return this.Mapper.Map<City>(result);
        }

        public async Task<City> UpdateAsync(CityUpdateModel city)
        {
            var existing = await this.Get(city);

            var result = this.Mapper.Map(city, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<City>(result);
        }

        public async Task<City> GetByAsync(ICityContainer city)
        {
            return city.CityId.HasValue 
                ? this.Mapper.Map<City>(await this.Context.City.FirstOrDefaultAsync(x => x.Id == city.CityId)) 
                : null;
        }

        private async Task<MusicTour.DataAccess.Entities.City> Get(ICityIdentity city)
        {
            if(city == null)
                throw new ArgumentNullException(nameof(city));
            return await this.Context.City.FirstOrDefaultAsync(x => x.Id == city.Id);
        }
    }
}