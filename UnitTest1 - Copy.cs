namespace TAF
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests1 : PageTest
    {

        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync("https://stackoverflow.com/");
        }

        [Test]
        public async Task HomePage()
        {
            var navigation = Page.Locator(".s-navigation");
            var aboutLink = navigation.Locator("text=About");
            await aboutLink.ClickAsync();
            await Expect(Page).ToHaveURLAsync("https://stackoverflow.co/");

        }

        [Test]
        public async Task HomePage1()
        {
            var navigation = Page.Locator(".s-navigation");
            var aboutLink = navigation.Locator("text=For Teams");
            await aboutLink.ClickAsync();
            await Expect(Page).ToHaveURLAsync("https://stackoverflow.co/teams/");

        }

        [Test]
        public async Task HomePage2()
        {
            await HandleAcceptButtonAsync();

            var navigation = Page.Locator(".s-navigation");
            var aboutLink = navigation.Locator("text=Products");
            await aboutLink.ClickAsync();

            var dropdown = Page.Locator("id=products-popover");
            var labs = dropdown.Locator("text=Labs");
            await labs.ClickAsync();
            await Expect(Page).ToHaveURLAsync("https://stackoverflow.co/labs/");

            await HandleAcceptButtonAsync();
        }

        private async Task HandleAcceptButtonAsync()
        {
            var Cookies = await Page.QuerySelectorAsync("#onetrust-accept-btn-handler:visible");

            if (Cookies != null)
            {
                // Click on the accept button
                await Cookies.ClickAsync();

                // Print the result of the click operation
                Console.WriteLine("Clicked on the accept button.");
            }
            else
            {
                Console.WriteLine("The accept button is not visible.");
            }
        }
    }
}
