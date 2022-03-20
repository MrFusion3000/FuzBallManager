namespace WebApi
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        //builder.WithOrigins("https://localhost:44372",
                        //    "https://localhost:5001",
                        //    "https://localhost:4001")
                        //    "https://localhost:82")
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
    }

}
