namespace TAF
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {

        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync("https://playwright.dev");
        }

        [Test]
        public async Task HomePage()
        {
            await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
            var getStarted = Page.Locator("text=Get Started");
            await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");
            await getStarted.ClickAsync();
            await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
        }
    }
}
