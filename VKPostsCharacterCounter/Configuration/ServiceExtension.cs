using Microsoft.EntityFrameworkCore;
using VKPostsCharacterCounter.Services;

namespace VKPostsCharacterCounter.Configuration
{
    public static class ServiceExtension
    {
        public static void ConfigurePostgreSqlContext(this IServiceCollection services, IConfiguration config)
        {
            //services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureVkApi(this IServiceCollection services)
        {
            services.AddScoped<AuthVkSupporter>();
        }
    }
}
