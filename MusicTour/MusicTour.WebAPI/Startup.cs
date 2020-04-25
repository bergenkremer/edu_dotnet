using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MusicTour.BLL.Contracts;
using MusicTour.BLL.Implementation;
using MusicTour.DataAccess.Context;
using MusicTour.DataAccess.Contracts;
using MusicTour.DataAccess.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MusicTour.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            //BLL
            services.Add(new ServiceDescriptor(typeof(ICityCreateService),typeof(CityCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICityGetService),typeof(CityGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICityUpdateService),typeof(CityUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IBandCreateService),typeof(BandCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IBandGetService),typeof(BandGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IBandUpdateService),typeof(BandUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IConcertCreateService),typeof(ConcertCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IConcertGetService),typeof(ConcertGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IConcertUpdateService),typeof(ConcertUpdateService), ServiceLifetime.Scoped));
            
            //DataAccess
            services.Add(new ServiceDescriptor(typeof(ICityDataAccess), typeof(CityDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IBandDataAccess), typeof(BandDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IConcertDataAccess), typeof(ConcertDataAccess), ServiceLifetime.Transient));
            
            //DB Contexts
            services.AddDbContext<MusicTourContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("MusicTour")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MusicTourContext>();
                context.Database.EnsureCreated(); 
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}