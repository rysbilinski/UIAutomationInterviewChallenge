using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabbleDemo.TestCases;

namespace TrabbleDemo.TestCases
{
    class SearchCommunityTemplatesTCs:BaseTest
    {
        [Test]
        public async Task SearchCommunityTemplatesSuccess()
        {
            InitPageObjects();
            await welcomePage.SelectMenuItem("Community", "Files and templates");
            await communityLandingPage.SearchCommunity("favicon template");
            Assert.IsTrue(await communitySearchPage.AreSearchItemHeadersCorrectly("favicon template"));

        }
    }
}
