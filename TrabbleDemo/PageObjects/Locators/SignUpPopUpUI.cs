using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabbleDemo.PageObjects.Locators
{
    class SignUpPopUpUI
    {
        public static string txtEmail = "//input[@id = 'email']";
        public static string txtPassword = "//input[@id = 'current-password']";
        public static string btnCreateAccount = "//button[text() = 'Create account']";
    }
}
