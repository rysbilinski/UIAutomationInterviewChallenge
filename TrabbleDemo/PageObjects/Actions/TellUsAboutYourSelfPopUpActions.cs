using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabbleDemo.PageObjects.Locators;

namespace TrabbleDemo.PageObjects.Actions
{
    class TellUsAboutYourSelfPopUpActions:BaseActions
    {
        public TellUsAboutYourSelfPopUpActions(IPage page)
        {
            _page = page;
        }
        public async Task FillInYourselfDetailsForm(string name, string kindOfWork, bool isAgreeJoinFigma, bool isCreateAccountClicked)
        {
            if (!string.IsNullOrEmpty(name))
            {
                await FillInTextbox(WelcomePageUI.iframe, TellUsAboutYourSelfPopUpUI.txtName, name);
            }
            await SelectKindOfWork(kindOfWork);
            await ClickOnAgreeJoinFigmaCheckbox(isAgreeJoinFigma);
            if (isCreateAccountClicked)
            {
                await ClickOnElement(WelcomePageUI.iframe, TellUsAboutYourSelfPopUpUI.btnCreateAccount);
            }

        }

        public async Task SelectKindOfWork(string kindOfWork)
        {
            await ClickOnElement(WelcomePageUI.iframe, TellUsAboutYourSelfPopUpUI.ddlKindOfWork);
            await ClickOnElement(WelcomePageUI.iframe, TellUsAboutYourSelfPopUpUI.optKindOfWork(kindOfWork));
        }

        public async Task ClickOnAgreeJoinFigmaCheckbox(bool isAgree)
        {
            if (await IsCheckboxChecked(WelcomePageUI.iframe, TellUsAboutYourSelfPopUpUI.chkAgreeJoinFigma))
            {
                if (!isAgree)
                {
                    await ClickOnElement(WelcomePageUI.iframe, TellUsAboutYourSelfPopUpUI.chkAgreeJoinFigma);
                }
            }
            if (!await IsCheckboxChecked(WelcomePageUI.iframe, TellUsAboutYourSelfPopUpUI.chkAgreeJoinFigma))
            {
                if (isAgree)
                {
                    await ClickOnElement(WelcomePageUI.iframe, TellUsAboutYourSelfPopUpUI.chkAgreeJoinFigma);
                }
            }
        }
    }
}
