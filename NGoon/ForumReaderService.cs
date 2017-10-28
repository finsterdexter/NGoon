using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NGoon.Models;

namespace NGoon
{
    public class ForumReaderService : IForumReaderService
    {
        private readonly IForumHtmlFetcher _fetcher;
        private readonly IForumHtmlParser _parser;

        public ForumReaderService(IServiceProvider provider)
        {
            _fetcher = provider.GetService<IForumHtmlFetcher>();
            _parser = provider.GetService<IForumHtmlParser>();
            if (_fetcher == null || _parser == null)
            {
                throw new Exception("ForumReaderService could not load dependent types. Make sure to call AddForumReaderService() on your IServiceCollection to load dependencies.");
            }
        }

        public async Task<IEnumerable<Post>> GetNewPosts(int threadId)
        {
            var html = await _fetcher.GetNewPostsHtml(threadId);
            return await _parser.ExtractPosts(threadId, html);
        }

        public async Task<IEnumerable<Post>> GetPosts(int threadId, int userId, int perPage, int pageNumber)
        {
            var html = await _fetcher.GetPostsPageHtml(threadId, perPage, pageNumber, userId);
            return await _parser.ExtractPosts(threadId, html);
        }

        public async Task<ForumThread> GetThread(int threadId)
        {
            var html = await _fetcher.GetThreadHtml(threadId);
            return await _parser.ExtractThread(html);
        }

        public async Task<User> GetUser(int userId)
        {
            var html = await _fetcher.GetUser(userId);
            return await _parser.ExtractUser(html);
        }
    }
}
