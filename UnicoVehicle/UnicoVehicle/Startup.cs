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
            //connection
            services.AddScoped<Connection>();
            //Command Generator
            services.AddTransient<IUtils, Utils>();
            //DAL Classes
            services.AddTransient<ICountryDAL, CountryDAL>();
            services.AddTransient<IStateDAL, StateDAL>();
            services.AddTransient<IDistrictDAL, DistrictDAL>();
            services.AddTransient<IAccessoriesTypeDAL, AccessoriesTypeDAL>();
            services.AddTransient<IFuelTypeDAL, FuelTypeDAL>();
            services.AddTransient<IVehicleTypeDAL, VehicleTypeDAL>();
            services.AddTransient<IUserTypeDAL, UserTypeDAL>();
            services.AddTransient<ITransmissionTypeDAL, TransmissionTypeDAL>();
            services.AddTransient<IStatusDAL, StatusDAL>();
            services.AddTransient<IInsuranceTypeDAL, InsuranceTypeDAL>();
            services.AddTransient<ICylinderArrangementDAL, CylinderArrangementDAL>();
            services.AddTransient<ICompanyDAL, CompanyDAL>();
            services.AddTransient<ICompanyCountryDAL, CompanyCountryDAL>();
            services.AddTransient<IShowroomDAL, ShowroomDAL>();
            services.AddTransient<IUserDAL,UserDAL>();
            services.AddTransient<ICustomerDAL, CustomerDAL>();
            services.AddTransient<IInsuranceCompanyDAL, InsuranceCompanyDAL>();
            services.AddTransient<IShowroomReviewDAL, ShowroomReviewDAL>();
            services.AddTransient<IMiscellaneousCallsDAL, MiscellaneousCallsDAL>();
            services.AddTransient<IVehicleNameDAL, VehicleNameDAL>();
            services.AddTransient<IVehicleVariantDAL, VehicleVariantDAL>();
            services.AddTransient<IVehicleDAL, VehicleDAL>();
            services.AddTransient<IVehicleReviewDAL, VehicleReviewDAL>();
            services.AddTransient<IVehicleFeatureDAL, VehicleFeatureDAL>();
            //BLL Classes
            services.AddTransient<ICountryBll, CountryBll>();
            services.AddTransient<IStateBLL, StateBLL>();
            services.AddTransient<IDistrictBLL, DistrictBLL>();
            services.AddTransient<IAccessoriesTypeBLL, AccessoriesTypeBLL>();
            services.AddTransient<IFuelTypeBLL, FuelTypeBLL>();
            services.AddTransient<IVehicleTypeBLL, VehicleTypeBLL>();
            services.AddTransient<IUserTypeBLL, UserTypeBLL>();
            services.AddTransient<ITransmissionTypeBLL, TransmissionTypeBLL>();
            services.AddTransient<IStatusBLL, StatusBLL>();
            services.AddTransient<IInsuranceTypeBLL, InsuranceTypeBLL>();
            services.AddTransient<ICylinderArrangementBLL, CylinderArrangementBLL>();
            services.AddTransient<ICompanyBLL, CompanyBLL>();
            services.AddTransient<ICompanyCountryBLL, CompanyCountryBLL>();
            services.AddTransient<IShowroomBLL, ShowroomBLL>();
            services.AddTransient<IUserBLL, UserBLL>();
            services.AddTransient<ICustomerBLL, CustomerBLL>();
            services.AddTransient<IInsuranceCompanyBLL, InsuranceCompanyBLL>();
            services.AddTransient<IShowroomReviewBLL, ShowroomReviewBLL>();
            services.AddTransient<IMiscellaneousCallsBLL, MiscellaneousCallsBLL>();
            services.AddTransient<IVehicleNameBLL, VehicleNameBLL>();
            services.AddTransient<IVehicleVariantBLL, VehicleVariantBLL>();
            services.AddTransient<IVehicleBLL, VehicleBLL>();
            services.AddTransient<IVehicleReviewBLL, VehicleReviewBLL>();
            //services.AddTransient<>();
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
