using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
public class MyTest : PageTest
{
    private static Random random = new Random();

    [Test]
    public void Setup()
    {
    }

    [Test]
    public async Task SignUp()
    {
        //Browser
        await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 50,
        });

        //page
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        await page.GotoAsync("https://www.figma.com/");
        // Click text=Login
        await page.ClickAsync("text=Sign up");

        await page.FrameLocator(".css-zmtt66").Locator("#email").FillAsync(GenerateRandomString() + "@gmail.com");
        await page.FrameLocator(".css-zmtt66").Locator("#current-password").FillAsync("Phu_20222020");

        await page.FrameLocator(".css-zmtt66").Locator("button", new FrameLocatorLocatorOptions { HasTextString = "Create account" }).ClickAsync();

        await page.FrameLocator(".css-zmtt66").Locator("input[name=\"name\"]").FillAsync("Chu Thiên Phú");

        await page.FrameLocator(".css-zmtt66").Locator("#downshift-0-toggle-button").ClickAsync();

        await page.FrameLocator(".css-zmtt66").Locator("#downshift-0-item-0").ClickAsync();

        await page.FrameLocator(".css-zmtt66").Locator("#downshift-6-toggle-button").ClickAsync();

        await page.FrameLocator(".css-zmtt66").Locator("#downshift-6-item-1").ClickAsync();

        await page.FrameLocator(".css-zmtt66").Locator("#box").ClickAsync();

        await page.FrameLocator(".css-zmtt66").Locator("button", new FrameLocatorLocatorOptions { HasTextString = "Create account" }).ClickAsync();

        await Expect(page.FrameLocator(".css-zmtt66").Locator("text='Verify your email'")).ToBeVisibleAsync();
    }

    [Test]
    public async Task Login()
    {
        //Browser
        await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 50,
        });

        //page
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        await page.GotoAsync("https://www.figma.com/");

        await Login(page);

        await Expect(page.Locator(".workspace_icon--iconContainer--1gWYz")).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions { Timeout = 10000 });
    }

    [Test]
    public async Task CreateANewDesignFile()
    {
        //Browser
        await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 50,
        });

        //page
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        await page.GotoAsync("https://www.figma.com/");

        await Login(page);

        await CreateANewDesignFile(page);

        await Expect(page.Locator(".toolbar_view--toolbar--2396w")).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions { Timeout = 10000 });
    }

    [Test]
    public async Task RenameANewDesignFile()
    {
        //Browser
        await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 50,
        });

        //page
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        await page.GotoAsync("https://www.figma.com/");

        var fileName = GenerateRandomString();

        await Login(page);

        await CreateANewDesignFile(page);

        System.Threading.Thread.Sleep(10000);

        await page.Locator(".filename_view--titleWithToggleContainer--2D-PN").DblClickAsync();

        await page.Locator(".filename_view--pageTitleInput--2_1Bi").FillAsync(fileName);

        await page.Keyboard.DownAsync("Enter");

        await Expect(page.Locator(".filename_view--titleWithToggleContainer--2D-PN")).ToHaveTextAsync(fileName);
    }

    [Test]
    public async Task SearchTemplateInComunity()
    {
        //Browser
        await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 50,
        });

        //page
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        await page.GotoAsync("https://www.figma.com/");

        var fileName = GenerateRandomString();

        await Login(page);

        await page.Locator(".community_hub_link--sectionName--3mjGP").ClickAsync();

        await page.Locator(".search--communityLandingSearchInput--2CF6D").ClickAsync();

        await page.Locator(".search--communityLandingSearchInput--2CF6D").FillAsync("ant");

        await page.Keyboard.DownAsync("Enter");

        System.Threading.Thread.Sleep(5000);

        await Expect(page.Locator(".search_results_view--grid--1EP07 > div:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > a:nth-child(2) > div:nth-child(1)")).ToBeVisibleAsync();
    }

    private async Task CreateANewDesignFile(IPage page)
    {
        await page.Locator("a.new_file_creation_topbar--tile--3kkT4:nth-child(1) > span:nth-child(3)").ClickAsync();
    }

    private async Task Login(IPage page)
    {
        // Click text=Login
        await page.ClickAsync("text=Log in");

        //await page.FrameLocator(".css-zmtt66").Locator("#email").FillAsync("darknessdragon3d@gmail.com");
        //await page.FrameLocator(".css-zmtt66").Locator("#current-password").FillAsync("figma_2020");
        await page.FrameLocator(".css-zmtt66").Locator("#email").FillAsync("damducduy.it@gmail.com");
        await page.FrameLocator(".css-zmtt66").Locator("#current-password").FillAsync("Darkness@1995");
        await page.FrameLocator(".css-zmtt66").Locator("button", new FrameLocatorLocatorOptions { HasTextString = "Log in" }).ClickAsync();
    }
    private string GenerateRandomString()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 10)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}