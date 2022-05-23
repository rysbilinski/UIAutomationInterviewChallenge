using System;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
public class MyTest : PageTest
{
    [Test]
    public async Task Setup()
    {
        await Page.GotoAsync("http://eaapp.somee.com/");
    }

    [Test]
    public async Task Login()
    {
        // Click text=Login
        await Page.ClickAsync("text=Login");
        // Fill input[name="UserName"]
        await Page.FillAsync("#UserName", "admin");
        // Fill input[name="Password"]
        await Page.FillAsync("#Password", "password");
        await Page.ClickAsync("text=Log in");
        await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();
    }

    public async Task SignUp()
    {
        // Click text=Register
        await Page.Locator("text=Register").ClickAsync();
        // Click input[name="UserName"]
        await Page.Locator("input[name=\"UserName\"]").ClickAsync();
        // Fill input[name="UserName"]
        await Page.Locator("input[name=\"UserName\"]").FillAsync("tphu01253" + DateTime.Now.ToString("HH:mm:ss"));
        // Click input[name="Password"]
        await Page.Locator("input[name=\"Password\"]").ClickAsync();
        // Double click input[name="Password"]
        await Page.Locator("input[name=\"Password\"]").DblClickAsync();
        // Fill input[name="Password"]
        await Page.Locator("input[name=\"Password\"]").FillAsync("@t3PrR2ZyxSLQXQ");
        // Click input[name="ConfirmPassword"]
        await Page.Locator("input[name=\"ConfirmPassword\"]").ClickAsync();
        // Fill input[name="ConfirmPassword"]
        await Page.Locator("input[name=\"ConfirmPassword\"]").FillAsync("@t3PrR2ZyxSLQXQ");
        // Click input[name="Email"]
        await Page.Locator("input[name=\"Email\"]").ClickAsync();
        // Fill input[name="Email"]
        await Page.Locator("input[name=\"Email\"]").FillAsync("test123@gmail.com");
        // Click input:has-text("Register")
        await Page.Locator("input:has-text(\"Register\")").ClickAsync();
        await Expect(Page.Locator("text=Log off")).ToBeVisibleAsync();
    }
}