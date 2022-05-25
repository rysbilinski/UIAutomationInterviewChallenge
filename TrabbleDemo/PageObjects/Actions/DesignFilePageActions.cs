using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrabbleDemo.PageObjects.Locators;

namespace TrabbleDemo.PageObjects.Actions
{
    class DesignFilePageActions:BaseActions
    {
        public DesignFilePageActions(IPage page)
        {
            _page = page;
        }

        public async Task FillInFileName(string fileName)
        {
            await WaitForElementDisplayed(DesignFilePageUI.lblDraft);
            await ClickOnElement(DesignFilePageUI.lblFileName);
            await FillInTextbox(DesignFilePageUI.txtFileName, fileName);
        }

        public async Task BackToUserLandingPage()
        {
            await ClickOnElement(DesignFilePageUI.iconToolHand);
            Thread.Sleep(1000);
            await ClickOnElement(DesignFilePageUI.lblDraft);
        }
    }
}
