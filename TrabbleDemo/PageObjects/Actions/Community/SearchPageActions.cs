using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabbleDemo.PageObjects.Locators.Community;

namespace TrabbleDemo.PageObjects.Actions.Community
{
    class SearchPageActions:BaseActions
    {
        public SearchPageActions(IPage page)
        {
            _page = page;
        }
        public async Task<bool> AreSearchItemHeadersCorrectly(string searchValue)
        {
            bool areAllMatched = true;
            string[] arraySearchValue = searchValue.Split(' ');
            await _page.WaitForSelectorAsync(SearchPageUI.searchItemHeaders);
            var listHeaders = _page.Locator(SearchPageUI.searchItemHeaders).AllTextContentsAsync();
            foreach (var header in listHeaders.Result)
            {
                var listValue = new List<bool>();
                listValue.Add(header.ToString().ToLower().Contains(arraySearchValue[0].ToLower()));
                foreach (var isContained in listValue)
                {
                    if (!isContained)
                    {
                        areAllMatched = false;
                        break;
                    }
                }
            }
            return areAllMatched;
        }
    }
}
