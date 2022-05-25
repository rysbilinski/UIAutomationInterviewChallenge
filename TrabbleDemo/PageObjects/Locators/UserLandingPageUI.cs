using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabbleDemo.PageObjects.Locators
{
    class UserLandingPageUI
    {
        public static string email = "//div[contains(@class, 'navbar--workspaceSubtitle')]";
        public static string btnNewDesignFile = "//div[@data-testid = 'new-design-file-button']";
        public static string lblFirstFileHeader = "(//div[contains(@class, 'generic_tile--title')])[1]";
    }
}
