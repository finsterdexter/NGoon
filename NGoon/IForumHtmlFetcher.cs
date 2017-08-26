using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NGoon
{
    internal interface IForumHtmlFetcher
    {
        // showthread.php?threadid=int&userid=0&perpage=40&pagenumber=1
        Task<string> GetThreadHtml(int threadId);

        // showthread.php?threadid=int&userid=0&perpage=40&pagenumber=int
        Task<string> GetPostsPageHtml(int threadId, int perPage, int pageNumber, int userId);

        // showthread.php?threadid=int&goto=newpost
        Task<string> GetNewPostsHtml(int threadId);

        // member.php?action=getinfo&userid=int
        Task<string> GetUser(int userId);
    }
}
