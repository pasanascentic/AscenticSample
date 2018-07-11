using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascentic.Sample.Mapper;
using Ascentic.Sample.Providers;
using Ascentic.Sample.Providers.Dependencies;
using Ascentic.Sample.Repositories;
using Ascentic.Sample.Repositories.Context;
using Ascentic.Sample.Repositories.Dependencies;
using Ascentic.Sample.Repositories.Dependencies.EntityRepositories;
using Ascentic.Sample.Repositories.EntityRepositories;
using Ascentic.Sample.Services;
using Ascentic.Sample.Services.Dependencies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ascentic.Sample.WebApi
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
            services.AddMvc();

            //// DEPENDENCY INJECTION
            // Unit of work dependencies
            services.AddSingleton<IAscenticDbContextFactory>(new AscenticDbContextFactory(Configuration));
            services.AddTransient<IUnitOfWork, AscenticUnitOfWork>();

            // Repository dependencies
            services.AddTransient<INewsRepository, NewsRepository>();

            // Provider dependencies
            services.AddTransient<INewsProvider, NewsProvider>();

            // Service dependencies
            services.AddTransient<INewsService, NewsService>();

            //// Auto Mapper Configuration Initialize
            AutoMapperConfig.Initialize();

            //// Core configuration
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowSpecificOrigin");

            app.UseMvc();
        }
    }
}
