using Microsoft.Playwright;
using MyPlaywrightPOC.Utils;
using NUnit.Framework;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;


namespace MyPlaywrightPOC.Tests
{
    public class BaseTest
    {
        protected TestSettings setting;
        protected IPlaywright playwright;
        protected IBrowser browser;
        protected IPage page;
        
        [SetUp]
        public async Task Setup()
        {
            var json = await File.ReadAllTextAsync("Config/testsettings.json");
            setting = JsonSerializer.Deserialize<TestSettings>(json);

            playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Channel = "chrome",
                Headless = false
            });

            page = await browser.NewPageAsync();
            await page.GotoAsync(setting.TestUrl);
            await Task.Delay(2000);

        }

        [TearDown]
        public async Task Teardown()
        {
            if (page != null) await page.CloseAsync();
            if (browser != null) await browser.CloseAsync();
            playwright?.Dispose();
        }
        //protected async Task HighlightAsync(string xpath, int durationMs = 1000)
        //{
        //    // Find the element handle using XPath
        //    var element = await page.QuerySelectorAsync($"xpath={xpath}");
        //    if (element != null)
        //    {
        //        // Add a red border using JavaScript
        //        await element.EvaluateAsync(@"(el, duration) => {
        //    const original = el.style.boxShadow;
        //    el.style.boxShadow = '0 0 0 3px #ff0000, 0 0 10px 3px #ff0000';
        //    setTimeout(() => { el.style.boxShadow = original; }, duration);
        //}", durationMs);
        //    }
        //}


      
    
    }
}
