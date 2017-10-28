using System;
using System.Collections.Generic;
using System.Text;

namespace NGoon.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int ThreadId { get; set; }
        public User Author { get; set; }
        public DateTimeOffset PostDate { get; set; }
        public string PostBody { get; set; }
        public string EditedByString { get; set; }
    }
}
