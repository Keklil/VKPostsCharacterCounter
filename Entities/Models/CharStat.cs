using System;
using System.Collections.Generic;

namespace VKPostsCharacterCounter
{
    public partial class CharStat
    {
        public Guid Id { get; set; }
        public DateTime? Date { get; set; }
        public string? Data { get; set; }
    }
}
