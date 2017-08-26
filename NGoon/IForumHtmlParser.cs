using NGoon.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NGoon
{
    internal interface IForumHtmlParser
    {
        Task<IEnumerable<Post>> ExtractPosts(string html);

        Task<ForumThread> ExtractThread(string html);

        Task<User> ExtractUser(string html);
    }
}
