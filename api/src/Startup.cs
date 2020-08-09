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
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

using Microsoft.EntityFrameworkCore;
using api.Domain.Repositories;
using api.Domain.Services;
using api.Persistence.Repositories;
using api.Services;
using api.Persistence.Contexts;

namespace api
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
            //TODO: Mudar para docker no final
            services.AddDbContext<AppDbContext>( 
                optionsAction => optionsAction.UseNpgsql(Configuration.GetConnectionString("Conexao"))
                );
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityService, CityService>();

            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", 
                    new OpenApiInfo {
                        Title = "Desafio Linx - API",
                        Version = "v1",
                        Description = "Resposta ao desafio da Linx, criando uma API REST in ASP.NET Core",
                        Contact = new OpenApiContact
                            {
                                Name = "George L. 'Maverick' Maluf",
                                Url = new Uri("https://github.com/GeorgeLMaluf/")
                            }
                    });
            });            

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            //app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI (config => {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Linx V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
