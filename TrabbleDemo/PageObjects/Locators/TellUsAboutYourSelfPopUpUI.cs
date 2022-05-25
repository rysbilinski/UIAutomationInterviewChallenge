using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabbleDemo.PageObjects.Locators
{
    class TellUsAboutYourSelfPopUpUI
    {
        public static string txtName = "//input[@name = 'name']";
        public static string ddlKindOfWork = "//div[contains(@class, 'branded_inputs')]/button";
        public static string optKindOfWork(string option) 
        {
            return $"//li[contains(@class, 'branded_inputs')][text() = '{option}']";
        }
        public static string btnCreateAccount = "//button[text() = 'Create account']";
        public static string chkAgreeJoinFigma = "//input[@id = 'box']";
    }
}
