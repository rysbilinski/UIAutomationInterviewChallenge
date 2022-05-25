using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabbleDemo.PageObjects.Locators
{
    class DesignFilePageUI
    {
        public static string lblFileName = "//span[@data-testid = 'filename']";
        public static string txtFileName = "//input[contains(@class, 'pageTitleInput')]";
        public static string mainMenu = "//div[@data-tooltip = 'main-menu']";
        public static string iconToolHand = "//div[@data-testid = 'set-tool-hand']";
        public static string lblDraft = "//div[contains(@class, 'filename_view--folderName')]";
    }
}
