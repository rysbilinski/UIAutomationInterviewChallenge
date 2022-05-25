using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabbleDemo.PageObjects.Locators;

namespace TrabbleDemo.PageObjects.Actions
{
    class WelcomePageActions:BaseActions
    {
        public WelcomePageActions(IPage page)
        {
            _page = page;
        }

        public async Task ClickButtonSignUp()
        {
            await ClickOnElement(WelcomePageUI.btnSignUp);
        }

        public async Task ClickButtonLogin()
        {
            await ClickOnElement(WelcomePageUI.btnLogin);
        }

        public async Task SelectMenuItem(string item, string subItem)
        {
            switch (item)
            {
                case "Community":
                    await ClickOnElement(WelcomePageUI.TopMenuItem(item));
                    if(subItem.Equals("Files and templates"))
                    {
                        await ClickOnElement(WelcomePageUI.itemCommunity_filesAndTemplates);
                    }
                    if (subItem.Equals("Plugins and widgets"))
                    {
                        await ClickOnElement(WelcomePageUI.itemCommunity_pluginsAndWidgets);
                    }
                    break;
            }
        }
    }
}
