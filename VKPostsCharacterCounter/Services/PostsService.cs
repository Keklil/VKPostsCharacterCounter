using VkNet;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;
using VKPostsCharacterCounter.Abstract;
using System;
using System.Collections.Generic;

namespace VKPostsCharacterCounter.Services
{
    public class PostsService
    {
        private IVkApi _api { get; set; }
        public PostsService(IVkApi api)
        {
            _api = api;
        }

        public async Task<List<string>> Search()
        {
            WallGetParams @params = new WallGetParams()
            {
                OwnerId = 264854715,
                Count = 5,
                Filter = VkNet.Enums.SafetyEnums.WallFilter.Owner
            };
            WallGetObject wallGetObject = await _api.Wall.GetAsync(@params);

            var list = new List<string>();
            foreach (var post in wallGetObject.WallPosts)
            {
                list.Add(post.Text);
            }
            return list;
        }
    }
}
