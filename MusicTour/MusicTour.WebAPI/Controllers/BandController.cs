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
    [Route("api/band")]
    public class BandController : ControllerBase
    {
        private ILogger<BandController> Logger { get; }
        private IBandCreateService BandCreateService { get; }
        private IBandGetService BandGetService { get; }
        private IBandUpdateService BandUpdateService { get; }
        private IMapper Mapper { get; }

        public BandController(ILogger<BandController> logger, IMapper mapper, IBandCreateService bandCreateService, IBandGetService bandGetService, IBandUpdateService bandUpdateService)
        {
            this.Logger = logger;
            this.BandCreateService = bandCreateService;
            this.BandGetService = bandGetService;
            this.BandUpdateService = bandUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<BandDTO> PutAsync(BandCreateDTO band)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.BandCreateService.CreateAsync(this.Mapper.Map<BandUpdateModel>(band));

            return this.Mapper.Map<BandDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<BandDTO> PatchAsync(BandUpdateDTO band)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.BandUpdateService.UpdateAsync(this.Mapper.Map<BandUpdateModel>(band));

            return this.Mapper.Map<BandDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<BandDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<BandDTO>>(await this.BandGetService.GetAsync());
        }

        [HttpGet]
        [Route("{bandId}")]
        public async Task<BandDTO> GetAsync(int bandId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {bandId}");

            return this.Mapper.Map<BandDTO>(await this.BandGetService.GetAsync(new BandIdentityModel(bandId)));
        }
    }
}