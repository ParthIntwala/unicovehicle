using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UnicoVehicle.Utilities;
using UnicoVehicle.DAL;
using UnicoVehicle.BLL;

namespace UnicoVehicle
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
            ConnectionProvider connection = new ConnectionProvider();

            Configuration.Bind("ConnectionStrings", connection);
            services.AddSingleton(connection);
            services.AddScoped<Connection>();
            services.AddTransient<IUtils, Utils>();
            services.AddTransient<ICountryDAL, CountryDAL>();
            services.AddTransient<IStateDAL, StateDAL>();
            services.AddTransient<IDistrictDAL, DistrictDAL>();
            services.AddTransient<IAccessoriesTypeDAL, AccessoriesTypeDAL>();
            services.AddTransient<ICountryBll, CountryBll>();
            services.AddTransient<IStateBLL, StateBLL>();
            services.AddTransient<IDistrictBLL, DistrictBLL>();
            services.AddTransient<IAccessoriesTypeBLL, AccessoriesTypeBLL>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
