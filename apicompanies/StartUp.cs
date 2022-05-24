using apicompanies.Db;
using Microsoft.EntityFrameworkCore;

namespace apicompanies
{
    public class StartUp
    {
        string _MyAllowSpecificOrigins = "_MyAllowSpecificOrigins";
        public IConfiguration _configuration { get; }
        public StartUp(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigurationServices(IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddControllers();
            services.AddDbContext<EnterpriseDb>(options => options.UseSqlServer(_configuration.GetConnectionString("defaultConnection")));

            services.AddCors(x =>
            {
                x.AddPolicy(name: _MyAllowSpecificOrigins,

                    builder =>
                    {
                        builder.WithOrigins("*")
                                .WithHeaders("*")
                                .WithMethods("*");
                    });
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configuration(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(_MyAllowSpecificOrigins);
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
        }
    }
}
