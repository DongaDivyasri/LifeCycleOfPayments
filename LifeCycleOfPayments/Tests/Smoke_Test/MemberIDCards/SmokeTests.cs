using Microsoft.Playwright;
using MyPlaywrightPOC.Tests;
using MyPlaywrightPOC.Utils;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPlaywrightPOC
{
    [TestFixture]
    [Category("PPD-145")]
    public class SmokeTests : BaseTest
    {

        [Test, Category("Smoke")]
        public async Task VerifyPageTitle()
        {

            await AssertionHighlights.HighlightAsync(page, MemberIDCardPage.MemberIdcard_Title);
            await page.InnerTextAsync(MemberIDCardPage.MemberIdcard_Title);
            await ScreenshotHelper.TakeScreenshotAsync(page);
            var titleText = await page.InnerTextAsync(MemberIDCardPage.MemberIdcard_Title);
            Assert.AreEqual("Member ID Cards", titleText, "Page title is incorrect");
            
        }

        [Test, Category("Smoke")]
        public async Task VerifyQuickSearchFields()
        {
            await AssertionHighlights.HighlightAsync(page,MemberIDCardPage.Recieptentname_Input);
            Assert.IsTrue(await page.IsVisibleAsync(MemberIDCardPage.Recieptentname_Input));
            
            Assert.IsTrue(await page.IsVisibleAsync(MemberIDCardPage.MemberID_Input));
            
            Assert.IsTrue(await page.IsVisibleAsync(MemberIDCardPage.Status_Dropdown));
          
            Assert.IsTrue(await page.IsVisibleAsync(MemberIDCardPage.DocumentID_Input));
           
            Assert.IsTrue(await page.IsVisibleAsync(MemberIDCardPage.SearchButton));
            await ScreenshotHelper.TakeScreenshotAsync(page);
        }

        [Test, Category("Smoke")]
        public async Task VerifyFilterIconVisibilityAndClickability()
        {
           
            Assert.IsTrue(await page.IsVisibleAsync(MemberIDCardPage.Filter_Icon));
            Assert.IsTrue(await page.IsEnabledAsync(MemberIDCardPage.Filter_Icon));
            await page.ClickAsync(MemberIDCardPage.Filter_Icon);
            await Task.Delay(2000);

        }


        [Category("PPD-3442")]

        [Test, Category("Smoke")]
        public async Task VerifyDropdownRendersWithStatusesAndSelectAll()
        {
            await page.ClickAsync(MemberIDCardPage.Status_Dropdown);
            var dropdownPanel = page.Locator(MemberIDCardPage.Status_Options);
           // await dropdownPanel.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });

            // Get all inner texts, split by newline, trim, and flatten into one list
            var actualStatuses = (await dropdownPanel.AllInnerTextsAsync())
                .SelectMany(s => s.Split('\n'))          // split multiple lines in one element
                .Select(s => s.Trim())                   // remove leading/trailing spaces
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct(StringComparer.OrdinalIgnoreCase) // avoid duplicates
                .ToList();

            // Expected statuses
            var expectedStatuses = new[]
            {
        "Select all", "Selected", "No statuses selected", "Unselected",
        "Cancelled", "Delivery address change", "Preparing", "Received", "Sent"
    };

            // Assertion
            var missing = expectedStatuses
                .Where(exp => !actualStatuses.Any(act => act.Equals(exp, StringComparison.OrdinalIgnoreCase)))
                .ToList();

          
            Assert.IsTrue(
                !missing.Any(),
                $"Dropdown missing expected statuses: {string.Join(", ", missing)}\n" +
                $"Expected: [{string.Join(", ", expectedStatuses)}]\n" +
                $"Actual: [{string.Join(", ", actualStatuses)}]"
            );

            await ScreenshotHelper.TakeScreenshotAsync(page);
        }





        

    }
}

