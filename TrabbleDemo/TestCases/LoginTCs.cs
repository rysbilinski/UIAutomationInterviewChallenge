using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrabbleDemo.TestCases
{
    class LoginTCs:BaseTest
    {
        [Test]
        public async Task LoginSuccess()
        {
            InitPageObjects();
            await welcomePage.ClickButtonLogin();
            await loginPopUp.Login("cong.trabble.demo+001@gmail.com", "Admin123", true);
            Assert.IsTrue(await userLandingPage.IsEmailVisible());
        }
    }
}
