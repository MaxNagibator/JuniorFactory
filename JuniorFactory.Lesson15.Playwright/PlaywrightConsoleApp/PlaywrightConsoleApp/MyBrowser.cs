using Microsoft.Playwright;

namespace PlaywrightConsoleApp
{
    internal class MyBrowser : IAsyncDisposable
    {
        private object lockBomzha;
        private IBrowser _browser;
        private IPage _currentPage;
        private readonly SemaphoreSlim _browserSemaphore = new(1, 1);

        public async Task<IBrowser> GetBrowserAsync()
        {
            if (_browser?.IsConnected == true)
            {
                return _browser;
            }

            await _browserSemaphore.WaitAsync();
            try
            {
                if (_browser?.IsConnected == true)
                {
                    return _browser;
                }

                await DisposeBrowserAsync();

                var playwright = await Playwright.CreateAsync();
                _browser = await playwright.Chromium.LaunchAsync(
                    new BrowserTypeLaunchOptions
                    {
                        Headless = false,
                        Timeout = 30000,
                    }
                );

                return _browser;
            }
            finally
            {
                _browserSemaphore.Release();
            }
        }

        private async ValueTask DisposeBrowserAsync()
        {
            if (_browser != null)
            {
                await _browser.DisposeAsync();
                _browser = null;
            }
        }

        public ValueTask DisposeAsync()
        {
            return DisposeBrowserAsync();
        }

        public async Task Login()
        {

            var browser = await GetBrowserAsync();
            //var context = await browser.NewContextAsync(new BrowserNewContextOptions
            //{
            //    ViewportSize = ViewportSize.NoViewport // Без фиксированного размера
            //});

            var page = await browser.NewPageAsync();

            //await page.SetViewportSizeAsync(1920, 1080);

            _currentPage = page;
            await page.GotoAsync("https://money.bob217.ru/");
            //try
            //{
            //    await page.Locator(".mud-nav-link.mud-ripple").WaitForAsync(new LocatorWaitForOptions() { Timeout = 5000 });
            //    var elements = await page.Locator(".mud-nav-link.mud-ripple").AllAsync();
            //    await elements[1].ClickAsync();
            //}
            //catch (Exception ex)
            //{
            // todo можно сделать без ошибки, а просто проверить видимость
           await page.Locator(".mud-button-root.mud-icon-button").First.WaitForAsync();
            //await page.Locator(".mud-button-root.mud-icon-button").First.ClickAsync();

                var elements2 = await page.Locator(".mud-nav-link.mud-ripple").AllAsync();
                await elements2[1].ClickAsync();
            //}

            var loginInput = await page.Locator(".mud-input-slot.mud-input-root.mud-input-root-text").AllAsync();
            var passwordInput = page.Locator("input[type='password']");
            await loginInput[0].FillAsync("demo");
            await passwordInput.FillAsync("123123");

            Thread.Sleep(1000);

            await page.Locator("//button[@type='submit']").ClickAsync();
        }

        internal async Task CreateOperation(string comment, int sum)
        {
            await ClickByXpath("(//*[contains(@class, 'mud-button-root') and contains(@class, 'mud-button')])[18]");

            var inputs = await _currentPage.Locator(".mud-input-slot.mud-input-root.mud-input-root-text").AllAsync();
            await inputs[0].FillAsync(sum.ToString());

            await inputs[4].ClickAsync();
            await (await _currentPage.Locator(".mud-list-item").AllAsync())[0].ClickAsync();

            await inputs[8].FillAsync(comment);

            //driver.FindElements(By.CssSelector(".mud-input-slot.mud-input-root.mud-input-root-text"))[8].Click();
            Thread.Sleep(1000);
            var btn = await _currentPage.Locator(".mud-button-root.mud-button.mud-button-filled").AllAsync();
            await btn[0].ClickAsync();
            Thread.Sleep(1000);
        }

        private async Task ClickByXpath(string xpath)
        {
            await _currentPage.Locator(xpath).WaitForAsync();
            var elem = await _currentPage.Locator(xpath).AllAsync();
            await elem[0].ClickAsync();
        }
    }
}
