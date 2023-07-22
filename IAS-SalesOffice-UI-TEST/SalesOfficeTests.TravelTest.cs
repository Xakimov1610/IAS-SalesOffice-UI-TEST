namespace IAS_SalesOffice_UI_TEST;

public partial class SalesOfficeTests
{
    /*      Test Create Travel 
        1 - travelni ochadi;
        2 - country tanlaydi;
        3 - start va end date larni tanlaydi;
        4 - person malumotlarini kiritib search qiladi;
        5 - contact qoship qoyadi;
        6 - bank pay ni tanlab pay qiladi;
        7 - finish buttonini bosadi;
    */

    public async Task TravelTest()
    {
        //await SignInToSystem(_siteUrl);

        // await Await Click(_menuInvoicePath);
        // await Task.Delay(TimeSpan.FromSeconds(4));
        // await SendKey(_searchActionInvoice, _statusAction);
        // await Task.Delay(TimeSpan.FromSeconds(2));
        //
        // await Click(_searchClickInvoice);
        // await Task.Delay(TimeSpan.FromSeconds(4));
        // await Click(_dropdownViewInvoicePath);
        // await Task.Delay(TimeSpan.FromSeconds(4));
        // await Click(_viewButtonPath);
        // await Task.Delay(TimeSpan.FromSeconds(4));
        //
        // var valueSearch = await GetValueString(_invoiceNumberText);
        // await Task.Delay(TimeSpan.FromSeconds(4));
        
        await Click(_createDealButton);
        await Task.Delay(TimeSpan.FromSeconds(4));
        
        await Click(_createTravelClick);
        await Task.Delay(TimeSpan.FromSeconds(13));

        await SendKey(_travelCountryInput, _country);
        await Task.Delay(TimeSpan.FromSeconds(4));
        
        await Click(_clickCountry);
        await Task.Delay(TimeSpan.FromSeconds(4));
        
        await Click(_startDateInput);
        await Task.Delay(TimeSpan.FromSeconds(4));
        
        await Click(_startDateDay);
        await Task.Delay(TimeSpan.FromSeconds(4));
        
        await Click(_endDateInput);
        await Task.Delay(TimeSpan.FromSeconds(4));
        
        await Click(_endDateDay);
        await Task.Delay(TimeSpan.FromSeconds(4));
       
        await Click(_programInput);
        await Task.Delay(TimeSpan.FromSeconds(4));
        
        await Click(_programInputClick);
        await Task.Delay(TimeSpan.FromSeconds(4));
        
        await SendKey(_dateOfBirthInput, _travelDateBirth);
        await Task.Delay(TimeSpan.FromSeconds(4));

        await Clear(_passSeriaInput);
        await SendKey(_passSeriaInput, _travelPassSeria);
        await Task.Delay(TimeSpan.FromSeconds(4));
        
        await Click(_passNumberInput);
        await Task.Delay(TimeSpan.FromSeconds(4));
        await SendKey(_passNumberInput, _travelPassNumber);
        await Task.Delay(TimeSpan.FromSeconds(4));
        
        await Click(_searchPersonButton);
        await Task.Delay(TimeSpan.FromSeconds(4));

        await Click(_personContactInput);
        await Task.Delay(TimeSpan.FromSeconds(4));
        
        await SendKey(_personContactInput, _travelPersonPhone);
        await Task.Delay(TimeSpan.FromSeconds(4));
        
        await Click(_policyBankPay);
        await Task.Delay(TimeSpan.FromSeconds(4));

        await Click(_payButton);
        await Task.Delay(TimeSpan.FromSeconds(4));
        
        await Click(_confirmationButton);
        await Task.Delay(TimeSpan.FromSeconds(4));


        //travelFinish click qilinganida 1c exception otadi
        
        
        await Click(_travelFinishButton);
        await Task.Delay(TimeSpan.FromSeconds(4));
    }
}