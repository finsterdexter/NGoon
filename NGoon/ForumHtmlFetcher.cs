using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NGoon
{
    internal class ForumHtmlFetcher : IForumHtmlFetcher
    {
        private readonly string _username;
        private readonly string _password;
        private static readonly HttpClient client = new HttpClient();

        public ForumHtmlFetcher(string username, string password)
        {
            _username = username;
            _password = password;
        }

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

        public async Task<string> GetUser(int userId)
        {
            var uri = new Uri(Constants.BaseUri, string.Format(Constants.UserUrlFormat, userId));
            return await GetHtml(uri);
        }

        private async Task<string> GetHtml(Uri uri, bool recursed = false)
        {
            try
            {
                var htmlString = await client.GetStringAsync(uri);
                if (htmlString.Contains("CLICK HERE TO REGISTER YOUR ACCOUNT"))
                {
                    await ForumLogin(_username, _password);
                    htmlString = await GetHtml(uri, true);
                }
                return htmlString;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task ForumLogin(string username, string password)
        {
            var values = new Dictionary<string, string>
            {
                { "action", "login"},
                { "next", "/" },
                { "username", username },
                { "password", password }
            };
            var content = new FormUrlEncodedContent(values);

            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, Constants.LoginActionUrl);
                requestMessage.Content = content;
                requestMessage.Headers.Referrer = new Uri("https://forums.somethingawful.com/account.php?action=loginform");

                var response = await client.SendAsync(requestMessage);
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException("Unsuccessful Login");
                }
                var responseString = await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
