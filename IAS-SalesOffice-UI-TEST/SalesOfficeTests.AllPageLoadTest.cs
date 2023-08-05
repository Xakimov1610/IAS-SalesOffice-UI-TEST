namespace IAS_SalesOffice_UI_TEST;

public partial class SalesOfficeTests
{
    public async Task AllPageLoadTest()
    {
        await Click(_allMenueDashbord_Path);
        await Task.Delay(2000);
        
        await Click(_allMenuSales_Path);
        await Task.Delay(2000);
        
        await Click(_allDeals_Path);
        await Task.Delay(8000);
        
        await Click(_allInvoice_Path);
        await Task.Delay(4000);
        
        await Click(_allPayments_Path);
        await Task.Delay(4000);
        
        await Click(_allBankPayment_Path);
        await Task.Delay(8000);
        
        await Click(_allPolicies_Path);
        await Task.Delay(4000);
        
        await Click(_allMenuProducts_Path);
        await Task.Delay(4000);
        
        await Click(_allMenuBsr_Path);
        await Task.Delay(8000);
        
        await Click(_allMenuSallerUsers_Path);
        await Task.Delay(4000);
        
        await Click(_allMenuNumberBuking_Path);
        await Task.Delay(2000);
        
        await Click(_allMenueReissue_Path);
        await Task.Delay(2000);
        
        await Click(_allMenueDashbord_Path);
        await Task.Delay(4000);
    }
}