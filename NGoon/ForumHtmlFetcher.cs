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
            return await GetHtml(uri);
        }

        public async Task<string> GetThreadHtml(int threadId)
        {
            var uri = new Uri(Constants.BaseUri, string.Format(Constants.ThreadUrlFormat, threadId, 1, 1, 0));
            return await GetHtml(uri);
        }

        public Task<string> GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        private async Task<string> GetHtml(Uri uri)
        {
            // TODO: login

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.Method = "GET";
            var response = await req.GetResponseAsync();
            using (var respStream = response.GetResponseStream())
            using (var reader = new StreamReader(respStream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
