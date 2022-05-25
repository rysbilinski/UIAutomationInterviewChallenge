using ActiveUp.Net.Mail;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrabbleDemo.PageObjects.Actions;

namespace TrabbleDemo.TestCases
{
    class RegisterTCs:BaseTest
    {
        [Test]
        public async Task RegisterSuccess()
        {
            InitPageObjects();
            Random randomNumber = new Random();
            string username = $"cong.trabble.demo+{randomNumber.Next()}@gmail.com";
            string password = "Admin123";
            await welcomePage.ClickButtonSignUp();
            await signUpPopUp.FillInRegisterForm(username, password, true);
            await tellUsAboutYourSelfPopUp.FillInYourselfDetailsForm(string.Empty, "Design", false, true);
            await verifyEmailPopUp.WaitForHeaderEnabled();
            Thread.Sleep(5 * 1000);
            string activeLink = GetActiveLink();
            await page.GotoAsync(activeLink);
            Assert.IsTrue(await welcomePopUp.IsPopUpHeaderVisible());
        }
    }
}
