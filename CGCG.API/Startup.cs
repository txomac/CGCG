using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGCG.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CGCG.API", Version = "v1" });
            });
            
            services.AddSingleton(typeof(IReferencesService), new ReferencesService());
            services.AddSingleton(typeof(IFournisseurs_ReferencesService), new Fournisseurs_ReferencesService());
            services.AddSingleton(typeof(IFournisseursService), new FournisseurService());
            services.AddSingleton(typeof(IPanier_Global_DetailService), new Panier_Global_DetailService());
            services.AddSingleton(typeof(IPanier_FournisseursService), new Panier_FournisseursService());
            services.AddSingleton(typeof(IPanier_GlobalService), new Panier_GlobalService());
            services.AddSingleton(typeof(IAdherentsService), new AdherentsService());
            services.AddSingleton(typeof(IPanier_AdherentsService), new Panier_AdherentsService());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CGCG.API v1"));
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
