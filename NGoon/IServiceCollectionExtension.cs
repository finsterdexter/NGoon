using AngleSharp.Parser.Html;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGoon
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddForumReaderService(this IServiceCollection services, string username, string password)
        {
            // di
            services.AddTransient<HtmlParser>();
            var fetcher = new ForumHtmlFetcher(username, password);
            services.AddTransient<IForumHtmlFetcher>((prov) => { return fetcher; });
            services.AddTransient<IForumHtmlParser, ForumHtmlParser>();

            return services;
        }
    }
}
