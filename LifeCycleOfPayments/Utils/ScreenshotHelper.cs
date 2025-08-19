using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MyPlaywrightPOC.Utils
{
    public static class ScreenshotHelper
    {
        public static async Task TakeScreenshotAsync(IPage page, string fileNamePrefix = null)
        {
            var screenshotsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Screenshots");
            Directory.CreateDirectory(screenshotsDir);

            var testName = TestContext.CurrentContext.Test.Name;
            var prefix = string.IsNullOrWhiteSpace(fileNamePrefix) ? testName : fileNamePrefix;
            var fileName = $"{prefix}_{DateTime.Now:yyyyMMdd_HHmmssfff}.png";
            var filePath = Path.GetFullPath(Path.Combine(screenshotsDir, fileName));

            await page.ScreenshotAsync(new PageScreenshotOptions { Path = filePath });
            TestContext.AddTestAttachment(filePath);
        }
    }
}