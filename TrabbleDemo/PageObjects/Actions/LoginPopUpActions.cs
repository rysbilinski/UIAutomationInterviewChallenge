using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabbleDemo.PageObjects.Locators;

namespace TrabbleDemo.PageObjects.Actions
{
    class LoginPopUpActions:BaseActions
    {
        public LoginPopUpActions(IPage page)
        {
            _page = page;
        }
        public async Task Login(string email, string password, bool isCreateAccountClicked)
        {
            await FillInTextbox(WelcomePageUI.iframe, LoginPopUpUI.txtEmail, email);
            await FillInTextbox(WelcomePageUI.iframe, LoginPopUpUI.txtPassword, password);
            if (isCreateAccountClicked)
            {
                await ClickOnElement(WelcomePageUI.iframe, LoginPopUpUI.btnLogin);
            }
        }
    }
}
