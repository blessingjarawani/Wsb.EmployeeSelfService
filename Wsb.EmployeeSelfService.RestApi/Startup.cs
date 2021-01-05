using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Interfaces;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses;
using WSB.EmployeeSelfService.DAL.DataContexts;
using WSB.EmployeeSelfService.DAL.Mapper;
using WSB.EmployeeSelfService.DAL.Repository;

namespace Wsb.EmployeeSelfService.RestApi
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
            services.AddMediatR(typeof(IBaseResponse).Assembly);
            services.AddControllers();
            services.AddDbContext<WSBEmployeeSelfServiceDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WSBEmployeeSelfServiceDataContext")));
            services.AddTransient<IEmployeeRepo, EmployeeRepo>();
            services.AddTransient<ILeaveApplicationRepo, LeaveApplicationRepo>();
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>(),
                            AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }

           // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
