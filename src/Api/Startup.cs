using Domain.Handlers;
using Domain.Interfaces;
using Domain.Mapping;
using Infrastructure.Context;
using Infrastructure.Repository;
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
            services.AddDbContext<OracleContext>(opt =>
            opt.UseOracle(Configuration.GetConnectionString("OracleConnection")));

            //MediatR
            services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(typeof(UpdateElementHandler).Assembly));

            //AutoMapper
            services.AddAutoMapper(typeof(EntityProfile).Assembly);

            //Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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
