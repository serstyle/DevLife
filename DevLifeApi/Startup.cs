using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevLifeApi.Models;
using DevLifeApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DevLifeApi
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
            // requires using microsoft.extensions.options
            services.Configure<DevLifeDatabaseSettings>(
                Configuration.GetSection(nameof(DevLifeDatabaseSettings)));

            services.AddSingleton<IDevLifeDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<DevLifeDatabaseSettings>>().Value);


            //services.Configure<DevLifeDatabaseSettings>(options =>
            //{
            //    options.ConnectionString
            //        = Configuration.GetSection("DevLifeDatabaseSettings:ConnectionString").Value;
            //    options.DatabaseName
            //        = Configuration.GetSection("DevLifeDatabaseSettings:Database").Value;
            //});
            
            services.AddSingleton<IStoryService, StoryService>();
            services.AddSingleton<VoteService>();
            services.AddSingleton<DbStartup>();
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
