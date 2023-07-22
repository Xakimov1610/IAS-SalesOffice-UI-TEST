namespace IAS_SalesOffice_UI_TEST;

public partial class SalesOfficeTests
{
    
    
    /*      Test case - Invoice

        1 - Invoice listga kirib closed search qilish;
        2 - Payment number olish va yopish;
        3 - Payment ka kirib search da number tanlash va search qilish;
        4 - Chiqan natijani tekshirish;        
    */
    public async Task InvoiceTest()
    {
        //await SignInToSystem(_siteUrl);
        await Click(_menuSalesFolderPath);
        await Click(_menuInvoicePath);
        await Task.Delay(TimeSpan.FromSeconds(4));
        await SendKey(_searchActionInvoice, _statusAction);
        await Task.Delay(TimeSpan.FromSeconds(2));

        await Click(_searchClickInvoice);
        await Task.Delay(TimeSpan.FromSeconds(4));
        await Click(_dropdownViewInvoicePath);
        await Task.Delay(TimeSpan.FromSeconds(4));
        await Click(_viewButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(4));

        var valueSearch = await GetValueString(_invoiceNumberText);
        await Task.Delay(TimeSpan.FromSeconds(4));

        await Click(_closeButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(8));
        await Click(_menuPaymentPath);
        await Task.Delay(TimeSpan.FromSeconds(8));
        await Click(_searchNumberPayment);
        await Task.Delay(TimeSpan.FromSeconds(3));
        await SendKey(_searchInputPayment, valueSearch);

        if (valueSearch is not null)
            await SendKey(_searchInputPayment, valueSearch);
        else
            Console.WriteLine("Fail");
        await Task.Delay(TimeSpan.FromSeconds(4));

        await Click(_searchButtonPayment);

        await Task.Delay(TimeSpan.FromSeconds(8));

        var tableNumberPayment = await GetValueString(_tableNumberPayment);

        await Task.Delay(TimeSpan.FromSeconds(4));

        if (valueSearch == tableNumberPayment)
            Console.WriteLine("Pass");
        else
            Console.WriteLine("Fail");
    }
}