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
            WallGetObject wallGetObject = await _api.Wall.GetAsync(new WallGetParams()
            {
                OwnerId = 264854715,
                Count = 5,
                Filter = VkNet.Enums.SafetyEnums.WallFilter.Owner
            });

            var list = new List<string>();
            foreach (var post in wallGetObject.WallPosts)
            {
                list.Add(post.Text);
            }
            return list;
        }

        public async Task<Dictionary<char, int>> CharCounter()
        {
            var output = new Dictionary<char, int>();
            var list = await Search();

            foreach (var item in list)
            {
                var itemConvert = new String(item.Where(x => Char.IsLetter(x)).ToArray()).ToLower();
                for (int i = 0; i < itemConvert.Length; i++)
                {
                    bool flag = output.ContainsKey(itemConvert[i]);
                    if (flag)
                    {
                        int count = output[itemConvert[i]];
                        output[itemConvert[i]] = ++count;
                    }
                    else
                    {
                        output[itemConvert[i]] = 1;
                    }
                }
            }

            return output;
        }
    }
}
