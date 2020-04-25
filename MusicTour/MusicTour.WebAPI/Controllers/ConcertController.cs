using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MusicTour.BLL.Contracts;
using MusicTour.Client.DTO.Read;
using MusicTour.Client.Requests.Create;
using MusicTour.Client.Requests.Update;
using MusicTour.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace MusicTour.WebAPI.Controllers
{
    [ApiController]
    [Route("api/concert")]
    public class ConcertController
    {
        private ILogger<ConcertController> Logger { get; }
        private IConcertCreateService ConcertCreateService { get; }
        private IConcertGetService ConcertGetService { get; }
        private IConcertUpdateService ConcertUpdateService { get; }
        private IMapper Mapper { get; }

        public ConcertController(ILogger<ConcertController> logger, IMapper mapper, IConcertCreateService concertCreateService, IConcertGetService concertGetService, IConcertUpdateService concertUpdateService)
        {
            this.Logger = logger;
            this.ConcertCreateService = concertCreateService;
            this.ConcertGetService = concertGetService;
            this.ConcertUpdateService = concertUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<ConcertDTO> PutAsync(ConcertCreateDTO concert)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.ConcertCreateService.CreateAsync(this.Mapper.Map<ConcertUpdateModel>(concert));

            return this.Mapper.Map<ConcertDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<ConcertDTO> PatchAsync(ConcertUpdateDTO concert)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.ConcertUpdateService.UpdateAsync(this.Mapper.Map<ConcertUpdateModel>(concert));

            return this.Mapper.Map<ConcertDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ConcertDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<ConcertDTO>>(await this.ConcertGetService.GetAsync());
        }

        [HttpGet]
        [Route("{concertId}")]
        public async Task<ConcertDTO> GetAsync(int concertId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {concertId}");

            return this.Mapper.Map<ConcertDTO>(await this.ConcertGetService.GetAsync(new ConcertIdentityModel(concertId)));
        }
    }
}