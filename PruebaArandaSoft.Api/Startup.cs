using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PruebaArandaSoft.Core.Interfaces;
using PruebaArandaSoft.Core.Servicios;
using PruebaArandaSoft.Infraestructura.Data;
using PruebaArandaSoft.Infraestructura.Repositorios;

namespace PruebaArandaSoft.Api
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
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(Configuration.GetSection("ConfiguracionAplicacion:" + "CorsPolicyOrigins").Value.Split('|'))
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddControllers();

            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IRolesService, RolesService>();
            services.AddTransient<IRolesPorUsuarioService, RolesPorUsuarioService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IRolesPorUsuarioRepository, RolesPorUsuarioRepository>();
            services.AddTransient<IRolesRepository, RolesRepository>();

            services.AddDbContext<BD_ArandaSoftContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("PruebaArandaSoft"));
            });
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
