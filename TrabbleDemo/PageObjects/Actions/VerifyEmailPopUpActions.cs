using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabbleDemo.PageObjects.Locators;

namespace TrabbleDemo.PageObjects.Actions
{
    class VerifyEmailPopUpActions:BaseActions
    {
        public VerifyEmailPopUpActions(IPage page)
        {
            _page = page;
        }

        public async Task WaitForHeaderEnabled()
        {
            await WaitForElementDisplayed(WelcomePageUI.iframe, VerifyEmailPopUpUI.header);
        }
    }
}
