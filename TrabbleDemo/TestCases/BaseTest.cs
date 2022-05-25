using ActiveUp.Net.Mail;
using HtmlAgilityPack;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.XPath;
using TrabbleDemo.Data;
using TrabbleDemo.PageObjects.Actions;
using TrabbleDemo.PageObjects.Actions.Community;
using TrabbleDemo.Utils;

namespace TrabbleDemo.TestCases
{
    class BaseTest
    {
        IBrowser browser;
        public IPage page;
        public MailUtils mailUtils;
        public WelcomePageActions welcomePage;
        public SignUpPopUpActions signUpPopUp;
        public LandingPageActions communityLandingPage;
        public SearchPageActions communitySearchPage;
        public TellUsAboutYourSelfPopUpActions tellUsAboutYourSelfPopUp;
        public VerifyEmailPopUpActions verifyEmailPopUp;
        public WelcomePopUpActions welcomePopUp;
        public LoginPopUpActions loginPopUp;
        public UserLandingPageActions userLandingPage;
        public DesignFilePageActions designFilePage;

        [SetUp]
        public async Task BeforeTest()
        {
            var playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Channel = "chrome" , Headless = false, SlowMo = 50, });
            // browser = await playwright.Chromium.LaunchAsync();
            var context = await browser.NewContextAsync(); ;
            page = await context.NewPageAsync();
            // await page.SetViewportSizeAsync(1920, 1080);
            await page.GotoAsync("https://www.figma.com/");
        }

        [TearDown]
        public async Task AfterTest()
        {
            await browser.CloseAsync();
        }
        public void InitPageObjects()
        {
            welcomePage = new WelcomePageActions(page);
            signUpPopUp = new SignUpPopUpActions(page);
            communityLandingPage = new LandingPageActions(page);
            communitySearchPage = new SearchPageActions(page);
            tellUsAboutYourSelfPopUp = new TellUsAboutYourSelfPopUpActions(page);
            verifyEmailPopUp = new VerifyEmailPopUpActions(page);
            welcomePopUp = new WelcomePopUpActions(page);
            loginPopUp = new LoginPopUpActions(page);
            userLandingPage = new UserLandingPageActions(page);
            designFilePage = new DesignFilePageActions(page);
        }

        public string GetActiveLink()
        {
            mailUtils = new MailUtils(ConfigurationData.MAIL_HOST, ConfigurationData.MAIL_PORT, ConfigurationData.MAIL_SSL,
                ConfigurationData.MAIL_USERNAME, ConfigurationData.MAIL_PASSWORD);
            //var body = mailUtils.GetFilteredMessageBody("support@figma.com", "Verify your email address");
            var listMessage = mailUtils.GetListFilteredMessageBody(ConfigurationData.MAIL_FROM, ConfigurationData.MAIL_SUBJECT);
            var body = listMessage[listMessage.Count - 1].BodyHtml.Text;
            var docHtml = new HtmlDocument();
            docHtml.LoadHtml(body);
            string link = docHtml.DocumentNode.SelectSingleNode("//a[contains(text(), 'Verify email')]").GetAttributeValue("href", string.Empty);
            return link;
        }
    }
}
