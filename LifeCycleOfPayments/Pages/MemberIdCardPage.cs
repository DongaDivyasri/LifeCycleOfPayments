using Microsoft.Playwright;
using System.Threading.Tasks;

namespace MyPlaywrightPOC
{
    public static class MemberIDCardPage
    {
        //Quick search fields
        public const string MemberIdcard_Title = "//span[@id='header-title']";
        public const string Recieptentname_Input = "//*[@class='searchOption']//label[text()='Recipient name']";
        public const string MemberID_Input = "//*[@class='searchOption']//label[text()='Member ID']";
        public const string Status_Dropdown = "//*[@class='searchOption']//span[text()='Status']";
        public const string DocumentID_Input = "//*[@class='searchOption']//label[text()='Document ID']";
        public const string SearchButton = "//button[normalize-space()='Search']";
        //Filter icon
        public const string Filter_Icon = "//i[@class='bi bi-sliders']";

        //Helper text
        public const string Helper_Text = "//p[@class='description']";

        // Search error popup
        public const string SearchError_popup = "//span[@class='ms-2']";

        public const string StatusDropdownValues = "//div[@class='filter-input-wrapper']";
        public const string Status_preparing = "//label[@class='checkbox-container']//span[contains(text(),'Preparing')]";
        public const string Status_Options = "//div[@class='filter-dropdown-menu']";
        public const string SelecetAllCheckbox = "//span[normalize-space()='Select all']";


        //Not yet used
        public const string PasswordInput = "//input[@name='uxPassword']";
        public const string TitleLabel = "//span[@id='header-title']";
        public const string CustomizeGrid_Link = "//a[normalize-space()='Customize grid']";
        public const string Customize_Text = "//h3[normalize-space()='Customize Grid']";
        public const string Close_Icon = "//button[normalize-space()='×']";
        public const string EditParameter = "//a[normalize-space()='Edit parameters']";
        public const string EditParameter_Text = "//strong[normalize-space()='Edit parameters']";
      

        public static async Task MemberIDCardAsync(IPage page, TestSettings setting)
        {
           
           
        }
    }
}