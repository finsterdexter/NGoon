using System;
using System.Collections.Generic;
using System.Text;

namespace NGoon.Models
{
    public class ForumThread
    {
        public int ThreadId { get; set; }
        public string Title { get; set; }
        public int AuthorUserId { get; set; }
        public int Replies { get; set; }
        public int Views { get; set; }
        public decimal Rating { get; set; }
    }
}
