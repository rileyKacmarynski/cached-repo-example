using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using FluentValidation.AspNetCore;
using MediatR;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Api;
using StackExchange.Redis;
using System;

namespace ChinookMusicStore.Api
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Chinook Music Store API", Version = "V1" });
            });

            string cacheConnection = Configuration.GetConnectionString("CacheConnection");
            services.AddSingleton(ConnectionMultiplexer.Connect(cacheConnection).GetDatabase());

            // this registers the IDistributedCache Interface to our redis cache
            // if we want to use the Execute method we need to register the cache
            // to the IDatabase interface
            //services.AddDistributedRedisCache(options =>
            //{
            //    options.Configuration = Configuration["CacheConnection"];
            //});

            services.AddScoped<IRepository<Track>, EfRepository<Track>>();
            services.AddScoped<IReadonlyRepository<Track>, DopeCachedTrackRepository>();

            services.AddScoped<ITrackService, TrackService>();

            services.AddDbContext<ChinookContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shinook Music Store API V!");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
