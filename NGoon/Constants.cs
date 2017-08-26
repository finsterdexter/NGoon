using System;
using System.Collections.Generic;
using System.Text;

namespace NGoon
{
    internal static class Constants
    {
        internal static Uri BaseUri => new Uri("https://forums.somethingawful.com/");
        internal static string ThreadUrlFormat => "showthread.php?threadid={0}&perpage={1}&pagenumber={2}&userid={3}";
    }
}
