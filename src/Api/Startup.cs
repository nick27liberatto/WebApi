using Domain.Mapping;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Database Context
            services.AddDbContext<OracleContext>(options =>
                options.UseOracle(Configuration.GetConnectionString("OracleConnection")));

            //AutoMapper
            services.AddAutoMapper(typeof(CrudMapper).Assembly);
            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
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
