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
    [Route("api/screening")]
    public class ConcertController
    {
        private ILogger<ConcertController> Logger { get; }
        private IConcertCreateService ConcertCreateService { get; }
        private IConcertGetService ConcertGetService { get; }
        private IConcertUpdateService ConcertUpdateService { get; }
        private IMapper Mapper { get; }

        public ConcertController(ILogger<ConcertController> logger, IMapper mapper, IConcertCreateService screeningCreateService, IConcertGetService screeningGetService, IConcertUpdateService screeningUpdateService)
        {
            this.Logger = logger;
            this.ConcertCreateService = screeningCreateService;
            this.ConcertGetService = screeningGetService;
            this.ConcertUpdateService = screeningUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<ConcertDTO> PutAsync(ConcertCreateDTO screening)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.ConcertCreateService.CreateAsync(this.Mapper.Map<ConcertUpdateModel>(screening));

            return this.Mapper.Map<ConcertDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<ConcertDTO> PatchAsync(ConcertUpdateDTO screening)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.ConcertUpdateService.UpdateAsync(this.Mapper.Map<ConcertUpdateModel>(screening));

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
        [Route("{screeningId}")]
        public async Task<ConcertDTO> GetAsync(int screeningId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {screeningId}");

            return this.Mapper.Map<ConcertDTO>(await this.ConcertGetService.GetAsync(new ConcertIdentityModel(screeningId)));
        }
    }
}