using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabbleDemo.PageObjects.Locators;

namespace TrabbleDemo.PageObjects.Actions
{
    class UserLandingPageActions:BaseActions
    {
        public UserLandingPageActions(IPage page)
        {
            _page = page;
        }

        public async Task<bool> IsEmailVisible()
        {
            return await IsElementVisible(UserLandingPageUI.email);
        }

        public async Task ClickNewDesignFileButton()
        {
            await ClickOnElement(UserLandingPageUI.btnNewDesignFile);
        }

        public async Task<string> GetTextFirstFileHeader()
        {
            return await GetElementText(UserLandingPageUI.lblFirstFileHeader);
        }

        public async Task SelectFirstFileHeader()
        {
            await DoubleClickOnElement(UserLandingPageUI.lblFirstFileHeader);
        }
    }
}
