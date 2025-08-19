using Microsoft.Playwright;
using MyPlaywrightPOC.Tests;
using NUnit.Framework;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPlaywrightPOC
{
    [TestFixture]
    [Category("PPD-145")]
    public class RegressionTests : BaseTest
    {

        [Test, Category("Regression"), Category("PPD-145")]
        public async Task R1_VerifyHelperTextBeforeSearch()
        {
            var helperText = await page.InnerTextAsync(MemberIDCardPage.Helper_Text);
            Assert.AreEqual("Please use at least one parameter to begin your search.", helperText);
        }

        [Test, Category("Regression")]
        public async Task R2_VerifyEditParametersLink()
        {
            Assert.IsTrue(await page.IsVisibleAsync(MemberIDCardPage.EditParameter));
            await page.ClickAsync(MemberIDCardPage.EditParameter);
            await Task.Delay(2000);
            var popupText = await page.InnerTextAsync(MemberIDCardPage.EditParameter_Text);
            Assert.AreEqual("Edit parameters", popupText, "Edit Parameters popup title mismatch");
        }

        [Test, Category("Regression")]
        public async Task R3_VerifyErrorMessageWhenSearchingWithoutParameters()
        {
            await page.ClickAsync(MemberIDCardPage.SearchButton);
            await Task.Delay(1000);
            var errorPopup = await page.InnerTextAsync(MemberIDCardPage.SearchError_popup);
            Assert.AreEqual("Please enter at least one search criteria to continue.", errorPopup, "Error message mismatch");
        }


    }
}
