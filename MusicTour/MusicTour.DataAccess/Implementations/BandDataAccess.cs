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
    public class BandDataAccess : IBandDataAccess
    {
        private MusicTourContext Context { get; }
        private IMapper Mapper { get; }

        public BandDataAccess(MusicTourContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Band> InsertAsync(BandUpdateModel band)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Band>(band));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Band>(result.Entity);
        }

        public async Task<IEnumerable<Band>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Band>>(
                await this.Context.Band.ToListAsync());
        }

        public async Task<Band> GetAsync(IBandIdentity band)
        {
            var result = await this.Get(band);

            return this.Mapper.Map<Band>(result);
        }

        public async Task<Band> UpdateAsync(BandUpdateModel band)
        {
            var existing = await this.Get(band);

            var result = this.Mapper.Map(band, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Band>(result);
        }

        public async Task<Band> GetByAsync(IBandContainer band)
        {
            return band.BandId.HasValue 
                ? this.Mapper.Map<Band>(await this.Context.Band.FirstOrDefaultAsync(x => x.Id == band.BandId)) 
                : null;
        }

        private async Task<MusicTour.DataAccess.Entities.Band> Get(IBandIdentity band)
        {
            if(band == null)
                throw new ArgumentNullException(nameof(band));
            return await this.Context.Band.FirstOrDefaultAsync(x => x.Id == band.Id);
        }
    }
}