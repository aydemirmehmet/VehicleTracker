using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApi.Contexts;
using VehicleTrackerApi.Mapping;
using VehicleTrackerApi.Services;
using VehicleTrackerApi.Services.Base;

namespace VehicleTrackerApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region Inject Repositories

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IVehiclePositionRepository, VehiclePositionRepository>();
            services.AddTransient<IPlaceRepository, PlaceRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            #endregion

            #region Inject AutoMapper
            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new PlaceProfile());
                mc.AddProfile(new ReportProfile());
                mc.AddProfile(new VehicleProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion
            services.AddDbContext<ApplicationDbContext>(options=>{
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    opt=> {
                          opt.UseNetTopologySuite();
                      });
            });
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VehicleTrackerApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VehicleTrackerApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
