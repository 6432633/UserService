using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using UserService.Data;

namespace UserService
{
    public class Startup
    {
        private IConfiguration _configuration {get;}

        public Startup(IConfiguration configuration){
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services){
            services.AddDbContext<UserContext>(options => options.UseNpgsql
            (_configuration.GetConnectionString("UserConnection")));
            services.AddControllers().AddNewtonsoftJson(s => 
                     s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            services.AddScoped<IUserRepository, SqlUserRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();   
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
