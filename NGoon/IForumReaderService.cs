using NGoon.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NGoon
{
    public interface IForumReaderService
    {
        Task<ForumThread> GetThread(int threadId);

        Task<IEnumerable<Post>> GetPosts(int threadId, int userId, int perPage, int pageNumber);

        Task<IEnumerable<Post>> GetNewPosts(int threadId);

        Task<User> GetUser(int userId);
    }
}
