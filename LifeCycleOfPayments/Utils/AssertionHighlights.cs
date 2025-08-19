using Microsoft.Playwright;
using System.Threading.Tasks;

namespace MyPlaywrightPOC.Utils
{
    public static class AssertionHighlights
    {
        public static async Task HighlightAsync(IPage page, string xpath, int durationMs = 1000)
        {
            var element = await page.QuerySelectorAsync($"xpath={xpath}");
            if (element != null)
            {
                await element.EvaluateAsync(@"(el, duration) => {
                    const original = el.style.boxShadow;
                    el.style.boxShadow = '0 0 0 3px #ff0000, 0 0 10px 3px #ff0000';
                    setTimeout(() => { el.style.boxShadow = original; }, duration);
                }", durationMs);
            }
        }
    }
}