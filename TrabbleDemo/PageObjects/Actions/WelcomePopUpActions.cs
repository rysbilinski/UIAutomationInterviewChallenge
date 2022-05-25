using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabbleDemo.PageObjects.Locators;

namespace TrabbleDemo.PageObjects.Actions
{
    class WelcomePopUpActions:BaseActions
    {
        public WelcomePopUpActions(IPage page)
        {
            _page = page;
        }

        public async Task<bool> IsPopUpHeaderVisible()
        {
            return await IsElementVisible(WelcomePopUpUI.header);
        }
    }
}
