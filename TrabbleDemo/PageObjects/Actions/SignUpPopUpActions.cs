using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabbleDemo.PageObjects.Locators;

namespace TrabbleDemo.PageObjects.Actions
{
    class SignUpPopUpActions:BaseActions
    {
        public SignUpPopUpActions(IPage page)
        {
            _page = page;
        }
        public async Task FillInRegisterForm(string email, string password, bool isCreateAccountClicked)
        {
            await FillInTextbox(WelcomePageUI.iframe, SignUpPopUpUI.txtEmail, email);
            await FillInTextbox(WelcomePageUI.iframe, SignUpPopUpUI.txtPassword, password);
            if (isCreateAccountClicked)
            {
                await ClickOnElement(WelcomePageUI.iframe, SignUpPopUpUI.btnCreateAccount);
            }
        }

    }
}
