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
    public class ConcertDataAccess : IConcertDataAccess
    {
        private MusicTourContext Context { get; }
        private IMapper Mapper { get; }

        public ConcertDataAccess(MusicTourContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Concert> InsertAsync(ConcertUpdateModel concert)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Concert>(concert));
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Concert>(result.Entity);
        }

        public async Task<IEnumerable<Concert>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Concert>>(await this.Context.Concert.Include(x => x.City).Include(x=>x.Band).ToListAsync());
        }

        public async Task<Concert> GetAsync(IConcertIdentity concertId)
        {

            var result = await this.Get(concertId);
            return this.Mapper.Map<Concert>(result);
        }
        
        private async Task<MusicTour.DataAccess.Entities.Concert> Get(IConcertIdentity concertId)
        {
            if (concertId == null)
                throw new ArgumentNullException(nameof(concertId));
            return await this.Context.Concert.Include(x => x.City).Include(x=>x.Band).FirstOrDefaultAsync(x => x.Id == concertId.Id);
            
        }

        public async Task<Concert> UpdateAsync(ConcertUpdateModel concert)
        {
            var existing = await this.Get(concert);

            var result = this.Mapper.Map(concert, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Concert>(result);
        }

        public async Task<Concert> GetByAsync(IConcertContainer concert)
        {
            return concert.ConcertId.HasValue 
                ? this.Mapper.Map<Concert>(await this.Context.Concert.FirstOrDefaultAsync(x => x.Id == concert.ConcertId)) 
                : null;
        }
    }
}