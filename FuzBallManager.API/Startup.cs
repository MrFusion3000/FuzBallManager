using Domain.Repositories;
using Domain.Repositories.Base;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MediatR;
using Application.Handlers.CommandHandlers;
using System.Reflection;
using Application;
using WebApi;
using Mapster;

namespace API
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
            services.ConfigureCors();
            services.AddControllers();
            services.AddDbContext<FBMContext>(m => m.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FBM.API", Version = "v1" });
            });

            var config = new TypeAdapterConfig();
            services.AddSingleton(config);

            MapsterMapster.MapsterSetter();
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(
                typeof(CreatePlayerHandler).GetTypeInfo().Assembly, 
                typeof(CreateManagerHandler).GetTypeInfo().Assembly, 
                typeof(CreateTeamHandler).GetTypeInfo().Assembly,
                typeof(CreateFixtureHandler).GetTypeInfo().Assembly);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IManagerRepository, ManagerRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IFixtureRepository, FixtureRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FBM.API v1"));
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
