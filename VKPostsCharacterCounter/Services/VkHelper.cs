using System;
using VkNet;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace VKPostsCharacterCounter.Services
{
    public class VkHelper
    {
        private readonly IVkApi _api;
        public VkHelper(IVkApi api)
        {
            _api = api;
        }
        public void Auth()
        {
            _api.Authorize(new ApiAuthParams
            {
                AccessToken = "47a3886f47a3886f47a3886fd047df3394447a347a3886f252829a611c22baad138499d",
                ApplicationId = 8174587,
                Settings = Settings.All
            });
        }
    }
}
