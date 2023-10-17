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
using Microsoft.Extensions.DependencyInjection;

namespace API
{

    //TODO - Make database InMemory

    public class Startup
    {
        readonly string MyAllowedSpecificOrigins = "_myAllowedSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();
            services.AddCors(options => 
            {
                options.AddPolicy(name: MyAllowedSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost",
                            "http://localhost:5000",
                            "https://localhost:5001",
                            "https://localhost:44397")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

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
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreatePlayerHandler).Assembly));
                //typeof(CreatePlayerHandler).GetTypeInfo().Assembly,
                //typeof(CreateManagerHandler).GetTypeInfo().Assembly, 
                //typeof(CreateTeamHandler).GetTypeInfo().Assembly,
                //typeof(CreateFixtureHandler).GetTypeInfo().Assembly
                //);

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
                app.UseCors("MyPolicy");
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
