using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestWithASPNETErudio.Model.Context;
using RestWithASPNETErudio.Services;
using RestWithASPNETErudio.Services.Implementations;

namespace RestWithASPNETUdemy {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();

            // pega a connection string do appsettings.json
            var connection = Configuration["MySQLConnection:MySQLConnectionString"];

            // registra o DbContext com MySQL
            services.AddDbContext<MySQLContext>(options =>
                options.UseMySql(
                    connection,
                    new MySqlServerVersion(new Version(8, 0, 36)) // ajuste para a versão do seu MySQL
                )
            );

            // Dependency Injection
            services.AddScoped<IPersonService, PersonServiceImplementation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
