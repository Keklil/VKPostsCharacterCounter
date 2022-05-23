using System;
using System.Collections.Generic;
using VkNet;
using VkNet.Model;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;

namespace VKPostsCharacterCounter.Services
{
    public class AuthVkSupporter
    {
        public AuthVkSupporter()
        {
            var api = new VkApi();
            api.Authorize(new ApiAuthParams
            {
                AccessToken = "47a3886f47a3886f47a3886fd047df3394447a347a3886f252829a611c22baad138499d"
            });
        }
    }
}
