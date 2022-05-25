using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabbleDemo.PageObjects.Locators.Community;

namespace TrabbleDemo.PageObjects.Actions.Community
{
    class LandingPageActions:BaseActions
    { 
        public LandingPageActions(IPage page)
        {
            _page = page;
        }

        public async Task SearchCommunity(string searchValue)
        {
            if (!string.IsNullOrEmpty(searchValue))
            {
                await FillInTextbox(LandingPageUI.txtSearchCommunity, searchValue);
                await ClickOnElement(LandingPageUI.iconSearch);
            }
        }
    }
}
