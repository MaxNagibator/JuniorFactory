// See https://aka.ms/new-console-template for more information
using Microsoft.Playwright;
using PlaywrightConsoleApp;

Console.WriteLine("Hello, World!");

var browser = new MyBrowser();
await browser.Login();

await browser.CreateOperation("Денюшки потратил", 217);
await Task.Delay(10000);