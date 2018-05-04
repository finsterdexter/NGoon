using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace NGoon.Tests
{
    public class ForumReaderServiceIntegrationTests
    {
        private readonly ForumReaderService _forumReaderService;
        

        public ForumReaderServiceIntegrationTests()
        {
            var services = new ServiceCollection();
            services.AddForumReaderService(TestConstants.username, TestConstants.password);
            var provider = services.BuildServiceProvider();
            _forumReaderService = new ForumReaderService(provider);
        }

        [Fact]
        public void GetThread_ShouldReturnCorrectThread()
        {
            var threadId = 3622381;
            var results = _forumReaderService.GetThread(threadId).Result;

            Assert.True(results.Title.Contains("xbox:"));
        }
    }
}
