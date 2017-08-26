using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NGoon
{
    internal class ForumHtmlFetcher : IForumHtmlFetcher
    {

        public Task<string> GetNewPostsHtml(int threadId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetPostsPageHtml(int threadId, int perPage, int pageNumber, int userId)
        {
            var uri = new Uri(Constants.BaseUri, string.Format(Constants.ThreadUrlFormat, threadId, perPage, pageNumber, userId));
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.Method = "GET";
            var response = await req.GetResponseAsync();
            using (var respStream = response.GetResponseStream())
            using (var reader = new StreamReader(respStream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public Task<string> GetThreadHtml(int threadId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
