﻿using VkNet;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using Newtonsoft.Json;

namespace VKPostsCharacterCounter.Services
{
    public class PostsService
    {
        private IVkApi _api;
        private ApplicationContext _context;
        public PostsService(IVkApi api, ApplicationContext context)
        {
            _api = api;
            _context = context;
        }

        public async Task<List<string>> Search()
        {
            WallGetObject wallGetObject = await _api.Wall.GetAsync(new WallGetParams()
            {
                OwnerId = 264854715,
                Count = 5,
                Filter = VkNet.Enums.SafetyEnums.WallFilter.Owner
            });

            var listOfPosts = new List<string>();
            foreach (var post in wallGetObject.WallPosts)
            {
                listOfPosts.Add(post.Text);
            }
            return listOfPosts;
        }

        public async Task<Dictionary<char, int>> CharCount()
        {
            var charStat = new Dictionary<char, int>();
            var listOfPosts = await Search();

            foreach (var item in listOfPosts)
            {
                var itemConvert = new String(item.Where(x => Char.IsLetter(x)).ToArray()).ToLower();
                for (int i = 0; i < itemConvert.Length; i++)
                {
                    bool flag = charStat.ContainsKey(itemConvert[i]);
                    if (flag == true)
                    {
                        int countOfChar = charStat[itemConvert[i]];
                        charStat[itemConvert[i]] = ++countOfChar;
                    }
                    else
                    {
                        charStat[itemConvert[i]] = 1;
                    }
                }
            }
            await SaveToDb(charStat);

            return charStat;
        }

        public async Task SaveToDb(Dictionary<char, int> charStat)
        {

            CharStat charStatDTO = new CharStat()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.UtcNow,
                Data = JsonConvert.SerializeObject(charStat)
            };
            await _context.Set<CharStat>().AddAsync(charStatDTO);
            await _context.SaveChangesAsync();
        }
    }
}
