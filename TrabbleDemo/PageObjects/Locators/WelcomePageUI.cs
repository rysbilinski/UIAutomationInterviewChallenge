using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabbleDemo.PageObjects.Locators
{
    class WelcomePageUI
    {
        public static string btnSignUp = "//div[@role = 'menubar']//a[contains(@href, 'signup')]";
        public static string btnLogin = "//div[@role = 'menubar']/button";
        public static string iframe = "//iframe[contains(@src, 'autofocus=true')]";
        public static string TopMenuItem(string item)
        {
            return $"//div[@role = 'menubar']//button[text() = '{item}']";
        }
        public static string itemCommunity_filesAndTemplates = "//a[@href = '/community/explore']";
        public static string itemCommunity_pluginsAndWidgets = "//a[@href = '/community/plugins']";
    }
}
