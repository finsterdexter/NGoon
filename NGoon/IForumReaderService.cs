using NGoon.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NGoon
{
    interface IForumReaderService
    {
        // showthread.php?threadid=int&userid=0&perpage=40&pagenumber=1
        Task<ForumThread> GetThread(int threadId);

        // showthread.php?threadid=int&userid=0&perpage=40&pagenumber=int
        Task<IEnumerable<Post>> GetPosts(int threadId, int userId, int perPage, int pageNumber);

        // showthread.php?threadid=int&goto=newpost
        Task<IEnumerable<Post>> GetNewPosts(int threadId);

        // member.php?action=getinfo&userid=int
        Task<User> GetUser(int userId);
    }
}
