// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium;
using SeleniumConsoleApp;

Console.WriteLine("Hello, World!");

var browser = new MyBrowser();
browser.Login();

browser.CreateOperation("Пирожок", 500);
//browser.CreateOperation("Сыр", 217);