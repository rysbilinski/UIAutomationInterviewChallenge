using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabbleDemo.PageObjects.Actions
{
    class BaseActions
    {
        protected IPage _page;

        public async Task ClickOnElement(string locator)
        {
            await _page.WaitForSelectorAsync(locator);
            await _page.ClickAsync(locator);
            await _page.WaitForLoadStateAsync();
        }

        public async Task ClickOnElement(string frameLocator, string locator)
        {
            await _page.FrameLocator(frameLocator).Locator(locator).ClickAsync();
            await _page.WaitForLoadStateAsync();
        }

        public async Task FillInTextbox(string locator, string value)
        {
            await _page.WaitForSelectorAsync(locator);
            await _page.FillAsync(locator, value);
        }

        public async Task FillInTextbox(string frameLocator, string locator, string value)
        {
            await _page.FrameLocator(frameLocator).Locator(locator).FillAsync(value);
        }

        public async Task<bool> IsCheckboxChecked(string locator)
        {
            return await _page.IsCheckedAsync(locator);
        }

        public async Task<bool> IsCheckboxChecked(string frameLocator, string locator)
        {
            return await _page.FrameLocator(frameLocator).Locator(locator).IsCheckedAsync();
        }

        public async Task WaitForElementDisplayed(string locator)
        {
            try
            {
                await _page.WaitForSelectorAsync(locator);
            }
            catch(Exception e)
            {
                var logExeption = e.Message;
                Console.WriteLine(logExeption);
            }
        }

        public async Task WaitForElementDisplayed(string frameLocator, string locator)
        {
            await _page.FrameLocator(frameLocator).Locator(locator).WaitForAsync();
        }

        public async Task<bool> IsElementVisible(string locator)
        {
            await WaitForElementDisplayed(locator);
            return await _page.IsVisibleAsync(locator);
        }

        public async Task<bool> IsElementVisible(string frameLocator, string locator)
        {
            return await _page.FrameLocator(frameLocator).Locator(locator).IsVisibleAsync();
        }

        public async Task<string> GetElementText(string locator)
        {
            await WaitForElementDisplayed(locator);
            return _page.InnerTextAsync(locator).Result;
        }

        public async Task<string> GetElementText(string frameLocator, string locator)
        {
            return await _page.FrameLocator(frameLocator).Locator(locator).TextContentAsync();
        }

        public async Task DoubleClickOnElement(string locator)
        {
            await _page.WaitForSelectorAsync(locator);
            await _page.DblClickAsync(locator);
            await _page.WaitForLoadStateAsync();
        }

        public async Task DoubleClickOnElement(string frameLocator, string locator)
        {
            await _page.FrameLocator(frameLocator).Locator(locator).DblClickAsync();
            await _page.WaitForLoadStateAsync();
        }
    }
}
