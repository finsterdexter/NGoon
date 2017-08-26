using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NGoon.Models;
using AngleSharp.Parser.Html;
using AngleSharp.Extensions;

namespace NGoon
{
    internal class ForumHtmlParser : IForumHtmlParser
    {
        private readonly HtmlParser _parser;

        internal ForumHtmlParser(HtmlParser parser)
        {
            _parser = parser;
        }

        public Task<IEnumerable<Post>> ExtractPosts(string html)
        {
            var doc = _parser.Parse(html);
            var output = new List<Post>();
            var postsHtmlCollection = doc.QuerySelectorAll("");
            foreach (var item in postsHtmlCollection)
            {
                
            }
            return Task.FromResult<IEnumerable<Post>>(output);
        }

        public Task<ForumThread> ExtractThread(string html)
        {
            var doc = _parser.Parse(html);
            throw new NotImplementedException();
        }

        public Task<User> ExtractUser(string html)
        {
            var doc = _parser.Parse(html);
            throw new NotImplementedException();
        }
    }
}
