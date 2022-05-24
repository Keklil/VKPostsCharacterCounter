using VkNet;
using Microsoft.EntityFrameworkCore;
using VKPostsCharacterCounter.Services;
using VkNet.Model;
using VkNet.Abstractions;

namespace VKPostsCharacterCounter.Configuration
{
    public static class ServiceExtension
    {
        public static void ConfigurePostgreSqlContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
        }

        public static void AddVkApi(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IVkApi>(x => {
                var api = new VkApi();
                api.Authorize(new ApiAuthParams { AccessToken = config["Vk:AccessToken"] });
                return api;
            });
        }

        public static void AddPostsService(this IServiceCollection services)
        {
            services.AddScoped<PostsService>();
        }
    }
}
