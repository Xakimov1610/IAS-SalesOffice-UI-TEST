using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace IAS_SalesOffice_UI_TEST;

public partial class SalesOfficeTests
{
    public async Task SignInToSystem(string url)
    {
        edgeDriver.Navigate().GoToUrl(url);

        await SendKey(_usernamePath, _username);
        await SendKey(_passwordPath, _password);
        await Click(_signInButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(7));

        await SendKey(_selectSellerInputPath, _sellerName);
        await Click(_selectSellerPath);
        await Click(_selectButtonPath);

        await Task.Delay(4000);
    }

    public Task Click(By elementPath)
    {
        var selectedElement = wait.Until(ExpectedConditions.ElementToBeClickable(elementPath));
        selectedElement.Click();
        return Task.CompletedTask;
    }

    public Task<string> GetValueString(By elementPath)
    {
        var selectedElement = wait.Until(ExpectedConditions.ElementExists(elementPath));
        return Task.FromResult(selectedElement.Text?.Trim() ?? string.Empty);
    }

    public Task SendKey(By elementPath, string key)
    {
        var selectedElement = wait.Until(ExpectedConditions.ElementToBeClickable(elementPath));
        selectedElement.SendKeys(key);
        return Task.CompletedTask;
    }

    public Task Clear(By elementPath)
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