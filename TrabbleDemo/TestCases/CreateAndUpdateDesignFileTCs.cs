using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrabbleDemo.TestCases
{
    class CreateAndUpdateDesignFileTCs:BaseTest
    {
        [Test]
        public async Task CreateDesignFileSuccess()
        {
            InitPageObjects();
            Random randomNumber = new Random();
            await welcomePage.ClickButtonLogin();
            await loginPopUp.Login("cong.trabble.demo+001@gmail.com", "Admin123", true);
            await userLandingPage.ClickNewDesignFileButton();
            string fileName = $"Create New File {randomNumber.Next()}";
            await designFilePage.FillInFileName(fileName);
            await designFilePage.BackToUserLandingPage();
            Assert.AreEqual(await userLandingPage.GetTextFirstFileHeader(),fileName);
        }

        [Test]
        public async Task UpdateDesignFileSuccess()
        {
            await CreateDesignFileSuccess();
            await userLandingPage.SelectFirstFileHeader();
            string fileName = $"Update file";
            await designFilePage.FillInFileName(fileName);
            await designFilePage.BackToUserLandingPage();
            Assert.AreEqual(await userLandingPage.GetTextFirstFileHeader(), fileName);
        }
    }
}
