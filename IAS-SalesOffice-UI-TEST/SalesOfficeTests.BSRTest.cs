namespace IAS_SalesOffice_UI_TEST;

public partial class SalesOfficeTests
{
    /*   Test BSR SO 

        1 - BSR ni ochadi va export to excel qiladi va kutadi;
        2 - Distrinbution stranisasiga otadi;
        2 - Return stranisasiga otadi;
        3 - Requests stranisasiga otadi;
        4 - Acquire request View sini ochadi keyin yopadi;
        5 - Return request stranisasiga otib View sini ochadi keyin yopadi;
        6 - State change stranisasini ochiq view sini koradi keyin yopadi;    
    */
    
    public async Task BSRTest()
    {
        await Click(_menuBSRPath);

        await Task.Delay(4000);
        await Click(_exportExcelButton);
        
        await Task.Delay(14000);
        await Click(_distributionButton);

        await Task.Delay(8000);
        await Click(_returnButton);

        await Task.Delay(8000);
        await Click(_requestsButton);

        await Task.Delay(5000);
        await Click(_aquireDropdownView);

        await Task.Delay(2000);
        await Click(_aquireButtonView);

        await Task.Delay(6000);
        await Click(_aquireViewClose);

        await Task.Delay(4000);
        await Click(_returnRequestButton);
        
        await Task.Delay(8000);
        await Click(_returnRequestViewDropdown);

        await Task.Delay(2000);
        await Click(_returnRequestViewButton);

        await Task.Delay(8000);
        await Click(_returnRequestCloseButton);

        await Task.Delay(3000);
        await Click(_stateChangeButton);

        await Task.Delay(8000);
        await Click(_stateChangeViewDropdown);

        await Task.Delay(2000);
        await Click(_stateChangeViewButton);

        await Task.Delay(8000);
        await Click(_stateChangeCloseButton);
        await Task.Delay(8000);
    }
}