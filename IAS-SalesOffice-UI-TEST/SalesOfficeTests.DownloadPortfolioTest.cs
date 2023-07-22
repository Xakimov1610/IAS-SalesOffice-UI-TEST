namespace IAS_SalesOffice_UI_TEST;

public partial class SalesOfficeTests
{
    public async Task DownloadPortfolioTest()
    {
        try
        {
            // await SignInToSystem(_siteUrl);
            //
            // await Task.Delay(4000);

            await Click(_menuSalesFolderPath);
            await Click(_menuSalesPath);

            await Task.Delay(8000);

            await Click(_downloadPortfolioButtonPath);
            await Clear(_startDateInputPath);
            await Click(_startDateSelectorPath);
            await Click(_downloadButtonPath);

            await Task.Delay(5000);
            KillBrowser();
        }
        catch (Exception ex)
        {
            KillBrowser();
        }
    }
}