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
    [Route("api/movie")]
    public class BandController : ControllerBase
    {
        private ILogger<BandController> Logger { get; }
        private IBandCreateService BandCreateService { get; }
        private IBandGetService BandGetService { get; }
        private IBandUpdateService BandUpdateService { get; }
        private IMapper Mapper { get; }

        public BandController(ILogger<BandController> logger, IMapper mapper, IBandCreateService movieCreateService, IBandGetService movieGetService, IBandUpdateService movieUpdateService)
        {
            this.Logger = logger;
            this.BandCreateService = movieCreateService;
            this.BandGetService = movieGetService;
            this.BandUpdateService = movieUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<BandDTO> PutAsync(BandCreateDTO movie)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.BandCreateService.CreateAsync(this.Mapper.Map<BandUpdateModel>(movie));

            return this.Mapper.Map<BandDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<BandDTO> PatchAsync(BandUpdateDTO movie)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.BandUpdateService.UpdateAsync(this.Mapper.Map<BandUpdateModel>(movie));

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
        [Route("{movieId}")]
        public async Task<BandDTO> GetAsync(int movieId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {movieId}");

            return this.Mapper.Map<BandDTO>(await this.BandGetService.GetAsync(new BandIdentityModel(movieId)));
        }
    }
}