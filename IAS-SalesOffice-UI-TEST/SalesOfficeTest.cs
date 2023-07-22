using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace IAS_SalesOffice_UI_TEST;

public class SalesOfficeTest
{
	private IWebDriver edgeDriver;
	private WebDriverWait wait;

	#region Basic Authorization

	private readonly By _usernamePath = By.XPath("//*[@id=\"username\"]");
	private readonly By _passwordPath = By.XPath("//*[@id=\"password\"]");
	private readonly By _signInButtonPath = By.XPath("/html/body/div[3]/div[3]/div[2]/div/div/div/div/form/button");

	private readonly By _selectSellerInputPath = By.XPath("//*[@id=\"menu-exp\"]/div[2]/div/div/div/input");
	private readonly By _selectSellerPath = By.XPath("//*[@id=\"menu-exp\"]/div[2]/div/div/div[2]");
	private readonly By _selectButtonPath = By.XPath("/html/body/div[2]/button");

	#endregion

	#region Download Portfolo Test
	
	private readonly By _menuSalesFolderPath = By.XPath("//*[@id=\"main-menu-navigation\"]/li[3]/a");
	private readonly By _menuSalesPath = By.XPath("//*[@id=\"main-menu-navigation\"]/li[3]/ul/li[1]/a");

	private readonly By _downloadPortfolioButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[1]/div/div[2]/div[2]/button[2]");
	private readonly By _startDateInputPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[6]/div/div/div[2]/input[2]");
	private readonly By _startDateSelectorPath = By.XPath("//*[@id=\"menu-exp\"]/div[7]/div[2]/div/div[2]/div/span[6]");
	private readonly By _downloadButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[6]/div/div/div[3]/button[2]");
	#endregion

	#region Invoive Test

	private readonly By _menuInvoicePath = By.XPath("//*[@id=\"main-menu-navigation\"]/li[3]/ul/li[2]/a");
	private readonly By _searchActionInvoice = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[1]/div/div[1]/div/div/input");
	private readonly By _searchClickInvoice = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[1]/div/div[1]/button");
	private readonly By _dropdownViewInvoicePath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[11]/div/div/button");

	private readonly By _viewButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[11]/div/div/div/a");
	private readonly By _invoiceNumberText = By.XPath("/html/body/div[6]/div[3]/div[1]/div[4]/div/div/div[2]/table/tbody/tr/td[2]");

	private readonly By _closeButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[4]/div/div/div[1]/button");
	private readonly By _menuPaymentPath = By.XPath("/html/body/div[4]/div[2]/ul/li[3]/ul/li[3]/a");
	private readonly By _searchNumberPayment = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[1]/div/div[1]/div/div/select/option[2]");

	private readonly By _searchInputPayment = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[1]/div/div[1]/div/div/input");

	private readonly By _searchButtonPayment = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[1]/div/div[1]/button");

	private readonly By _tableNumberPayment = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr/td[5]");


	#endregion


	#region ConstValues

	//private const string _username = "oakrom";
	//private const string _password = "123456";
	private const string _siteUrl = "https://sales.aic.uz";
	private const int _waitingSecond = 20;
	private const string _username = "n.xakimov";
	private const string _password = "654321";
	private const string _sellerName = "Head office";
	private const string _statusAction = "Closed";


	#endregion

	public SalesOfficeTest()
	{
		edgeDriver = new EdgeDriver();
		wait = new WebDriverWait(edgeDriver, TimeSpan.FromSeconds(_waitingSecond));
		DownloadPortfolioTest();
	}

	public async void DownloadPortfolioTest()
	{
		try
		{
			await SignInToSystem(_siteUrl);

			Thread.Sleep(4000);

			await Click(_menuSalesFolderPath);
			await Click(_menuSalesPath);

			Thread.Sleep(8000);

			await Click(_downloadPortfolioButtonPath);
			await Clear(_startDateInputPath);
			await Click(_startDateSelectorPath);
			await Click(_downloadButtonPath);

			Thread.Sleep(5000);
			KillBrowser();
		}
		catch (Exception ex)
		{
			KillBrowser();
		}
	}


	public async Task InvoiceTest()
	{
		//await SignInToSystem(_siteUrl);

		await Click(_menuInvoicePath);
		Thread.Sleep(4000);
		await SendKey(_searchActionInvoice, _statusAction);
		Thread.Sleep(2000);

		await Click(_searchClickInvoice);
		Thread.Sleep(4000);
		await Click(_dropdownViewInvoicePath);
		Thread.Sleep(4000);
		await Click(_viewButtonPath);
		Thread.Sleep(4000);

		var valueSearch = await GetValueString(_invoiceNumberText);
		Thread.Sleep(4000);

		await Click(_closeButtonPath);
		Thread.Sleep(8000);
		await Click(_menuPaymentPath);
		Thread.Sleep(8000);
		await Click(_searchNumberPayment);
		Thread.Sleep(3000);
		await SendKey(_searchInputPayment, valueSearch);

		if (valueSearch is not null)
			await SendKey(_searchInputPayment, valueSearch);
		else
			Console.WriteLine("Fail");
		Thread.Sleep(4000);

		await Click(_searchButtonPayment);

		Thread.Sleep(8000);

		var tableNumberPayment = await GetValueString(_tableNumberPayment);

		Thread.Sleep(4000);

		if (valueSearch == tableNumberPayment)
			Console.WriteLine("Pass");
		else
			Console.WriteLine("Fail");
	}

	private async Task SignInToSystem(string url)
	{
		edgeDriver.Navigate().GoToUrl(url);

		await SendKey(_usernamePath, _username);
		await SendKey(_passwordPath, _password);
		await Click(_signInButtonPath);

		Thread.Sleep(4000);

		//SendKey(wait, _selectSellerInputPath, _sellerName);
		//Click(wait, _selectSellerPath);
		//Click(wait, _selectButtonPath);

		//Thread.Sleep(4000);
	}

	private Task Click(By elementPath)
	{
		var selectedElement = wait.Until(ExpectedConditions.ElementToBeClickable(elementPath));
		selectedElement.Click();
		return Task.CompletedTask;
	}

	private Task<string> GetValueString(By elementPath)
	{
		var selectedElement = wait.Until(ExpectedConditions.ElementExists(elementPath));
		return Task.FromResult(selectedElement.Text?.Trim() ?? string.Empty);
	}

	private Task SendKey(By elementPath, string key)
	{
		var selectedElement = wait.Until(ExpectedConditions.ElementToBeClickable(elementPath));
		selectedElement.SendKeys(key);
		return Task.CompletedTask;
	}

	private Task Clear(By elementPath)
	{
		var selectedElement = wait.Until(ExpectedConditions.ElementToBeClickable(elementPath));
		selectedElement.Clear();
		return Task.CompletedTask;
	}


	public void KillBrowser()
	{
		edgeDriver.Quit();
	}
}
