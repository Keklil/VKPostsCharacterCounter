using VkNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using VKPostsCharacterCounter.Services;
using VkNet.Model;
using VkNet.Abstractions;
using System.Reflection;

namespace VKPostsCharacterCounter.Configuration
{
    public static class ServiceExtension
    {
        public static void ConfigurePostgreSqlContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Vk posts statistics",
                    Description = "API to get statistics on the number of letters in the first five posts on a personal Vk page."
                });            
                
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

            });
        }

        public static void AddVkApi(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IVkApi>(options => {
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
