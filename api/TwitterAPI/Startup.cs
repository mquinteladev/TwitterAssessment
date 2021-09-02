using AspNetCore.CacheOutput.Extensions;
using BusinessModel.Services;
using Domain;
using Interfaces;
using Interfaces.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TwitterAPI.HubConfig;
using TwitterAPI.Infrastructure;

namespace TwitterAPI
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Twitter API", Version = "v1" });
                c.CustomSchemaIds((type) => type.FullName);
            });

            RegisterServices(services);

            services.AddSignalR();

            services.AddResponseCaching();

            services.AddResponseCompression();

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

            app.UseCors("CorsPolicy");

            app.UseResponseCompression();

            app.UseCacheOutput();

            app.UseResponseCaching();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("v1/swagger.json", "Twitter API V1"); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChartHub>("/chart");
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            var cache = new MemoryCache(new MemoryCacheOptions());
            services.AddSingleton<IMemoryCache>(cache);
            services.AddScoped<ITwitterUnitOfWork, TwitterUnitOfWork>();
            services.AddScoped<ICache, Domain.Storage.MemoryCache>();
            services.AddScoped<IAppConfiguration, AppConfiguration>();
            services.AddScoped<ITwitterApiFacade, TwitterApiFacade>();
            services.AddHostedService<StartupService>();
        }
    }
}
