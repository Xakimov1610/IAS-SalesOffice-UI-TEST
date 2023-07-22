namespace IAS_SalesOffice_UI_TEST;

public partial class SalesOfficeTests
{
    public async Task OSGOVTSTest()
    {
        await Click(_createDealButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(3));

        await Click(_createDealButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(3));

        await SendKey(_gosNumberPath, _gosnumber);
        await Task.Delay(TimeSpan.FromSeconds(3));

        await SendKey(_techPassSerPath, _techpasser);
        await Task.Delay(TimeSpan.FromSeconds(3));

        await SendKey(_techPassNumPath, _techpassnumber);
        await Task.Delay(TimeSpan.FromSeconds(3));

        await Click(_searchButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(6));

        await Click(_nextButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(5));

        await Click(_addButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(5));

        await SendKey(_dateOfBirthPath, _dateOfBirth);
        await Task.Delay(TimeSpan.FromSeconds(3));
        
        await SendKey(_passportSerPath, _passportSer);
        await Task.Delay(TimeSpan.FromSeconds(3));
        
        await SendKey(_passportNumPath, _passportNum);
        await Task.Delay(TimeSpan.FromSeconds(3));

        await Click(_pinflPath);
        await Task.Delay(TimeSpan.FromSeconds(3));
        
        await Click(_nextButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(5));
        
        await Click(_generateInvoicePath);
        await Task.Delay(TimeSpan.FromSeconds(6));
        
        await Click(_createInvoicePath);
        
        await Task.Delay(TimeSpan.FromSeconds(10));
        
        await Click(_actionButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(6));
        
        await Click(_payButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(10));
        
        await Click(_bankConPayButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(10));
        
        await Click(_setPayedButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(10));

        /* 1C bilan integratsiya bo'lmaganligi tufayli shu yerda error beradi, agar 1c ulansa ishlaydi  */
        
        await Click(_osgovtsCloseButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(10));
        
        await Click(_dealButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(10));
        
        await Click(_dealActionButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(10));
        
        await Click(_dealViewButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(10));
        
        await Click(_dashboardButtonPath);
        await Task.Delay(TimeSpan.FromSeconds(10));
    }
}