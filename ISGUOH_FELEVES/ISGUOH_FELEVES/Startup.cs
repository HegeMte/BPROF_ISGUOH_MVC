using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using Repository;
using Data;

namespace ISGUOH_FELEVES
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<PlayerLogic, PlayerLogic>();
            services.AddTransient<TeamLogic, TeamLogic>();
            services.AddTransient<LeagueLogic, LeagueLogic>();
            services.AddTransient<IRepository<Player>, PlayerRepo>();
            services.AddTransient<IRepository<Team>, TeamRepo>();
            services.AddTransient<IRepository<League>, LeagueRepo>();

            

            services.AddMvc(opt => opt.EnableEndpointRouting = false).AddRazorRuntimeCompilation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            
           
        }
    }
}
