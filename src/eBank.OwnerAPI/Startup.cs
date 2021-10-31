using Autofac;
using eBank.Infra.CrossCutting.IOC;
using eBank.Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace eBank.OwnerAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var host = Configuration["DBHOST"] ?? "127.0.0.1";
            var port = Configuration["DBPORT"] ?? "1433";
            var catalog = Configuration["DBCatalog"] ?? "ebank";
            var user = Configuration["DBUser"] ?? "sa";
            var pass = Configuration["DBPASS"] ?? "dti@1406";
            var sqlServerConn = $"Data Source={host};Initial Catalog={catalog};User ID={user};Password={pass};Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(sqlServerConn));

            services.AddControllers();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Swagger", Version = "v1" });
            });
        }

        public void ConfigureContainer(ContainerBuilder Builder)
        {
            Builder.RegisterModule(new ModuleIOC());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(opt => {

                opt.SwaggerEndpoint("/swagger/v1/Swagger.json", "Swagger V1");

            });
        }
    }
}
