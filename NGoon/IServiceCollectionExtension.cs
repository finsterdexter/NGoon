using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGoon
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddForumReaderService(this IServiceCollection services)
        {
            // di
            return services;
        }
    }
}
