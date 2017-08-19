using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NGoon.Models;

namespace NGoon
{
    public class ForumReaderService : IForumReaderService
    {
        public async Task<IEnumerable<Post>> GetNewPosts(int threadId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetPosts(int threadId, int userId, int perPage, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<ForumThread> GetThread(int threadId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
