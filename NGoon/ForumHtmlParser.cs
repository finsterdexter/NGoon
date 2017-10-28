using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using NGoon.Models;
using AngleSharp.Parser.Html;
using AngleSharp.Extensions;

namespace NGoon
{
    internal class ForumHtmlParser : IForumHtmlParser
    {
        private readonly HtmlParser _parser;

        public ForumHtmlParser(HtmlParser parser)
        {
            _parser = parser;
        }

        public Task<IEnumerable<Post>> ExtractPosts(int threadId, string html)
        {
            var doc = _parser.Parse(html);
            var output = new List<Post>();
            var postsHtmlCollection = doc.QuerySelectorAll("table.post");
            foreach (var item in postsHtmlCollection)
            {
                var post = new Post
                {
                    EditedByString = item.QuerySelector(".editedby").TextContent,
                    PostBody = item.QuerySelector(".postbody").Html(),
                    PostDate = DateTimeOffset.Parse(item.QuerySelector(".postdate").Text()),
                    PostId = int.Parse(item.GetAttribute("id").Substring(4)),
                    ThreadId = threadId
                };
                var userInfoElement = item.QuerySelector("td.userinfo");
                var userId = int.Parse(item.ClassList.Where(t => t.StartsWith("userid-")).First().Substring(7));
                var user = new User
                {
                    
                };
            }
            return Task.FromResult<IEnumerable<Post>>(output);
        }

        public Task<ForumThread> ExtractThread(string html)
        {
            var doc = _parser.Parse(html);
            var output = new ForumThread
            {
                ThreadId = int.Parse(doc.QuerySelector("#thread").ClassName.Split(':')[1]), // class="thread:12345678"
                Title = doc.QuerySelector("meta[name=\"Description\"]").GetAttribute("content"),
                // TODO: rest of the thread properties
            };
            return Task.FromResult(output);
        }

        public Task<User> ExtractUser(string html)
        {
            var doc = _parser.Parse(html);
            throw new NotImplementedException();
        }
    }
}
