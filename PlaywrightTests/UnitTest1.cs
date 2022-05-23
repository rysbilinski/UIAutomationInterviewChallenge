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
    public async Task Test1()
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
}