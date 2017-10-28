using System;
using System.Collections.Generic;
using System.Text;

namespace NGoon.Models
{
    public class User
    {
        public int UserId { get; set; }
        public bool IsPlatinum { get; set; }
        public DateTimeOffset Registered { get; set; }
        public string TitleHtml { get; set; }
    }
}
