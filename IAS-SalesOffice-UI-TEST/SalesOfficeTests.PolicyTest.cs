namespace IAS_SalesOffice_UI_TEST;

 /* Pliciy
      1 - Policies pageni ochish
      2 - Action dan 'Go to deal' ni bosish va policies pagega qaytish
      3 - Action dan 'View' ni bosish, modalni yopish
      4 - Global searchda 'EAPL' bilan qidirish + 'Status' i 'Active' larini qidirish
      5 - Action dan 'View' ni bosish, modalni yopish
      6 -Action dan 'Go to deal' ni bosib, Deal ni edit qilib, steplarini next-back qilib, Paymentni 3 marta print qilim next qilib Finishgacha boradi
 */
public partial class SalesOfficeTests
{
    public async Task PolicyTest()
    {
        //var wait = SignInToSystem("https://sales.aic.uz", 20);

        await Click(_menuSalesFolderPath);
        
        await Click(_menuPoliciesPath);
        await Task.Delay(4000);
        
        await SendKey(_globalSearchInputPath, "EAPL");
        await Click(_globalSearchButtonPath);
        await Task.Delay(3000);
        await Click(_globalSearchDropdownPath);
        await Click(_policyStatusButtonDropdownPath);
        await SendKey(_globalSearchInputPath, "Active");
        await Click(_globalSearchButtonPath);
        await Task.Delay(3000);
        
        await Click(_policyDropdownButtonPath);
        await Click(_policyViewButtonPath);
        await Task.Delay(2000);
        await Click(_policyModalCloseButtonPath);
        await Click(_policyDropdownButtonPath);
        await Click(_policyGoToDealButtonPath);
        await Task.Delay(3000);
        
        await Click(_policyDealEditButtonPath);
        await Task.Delay(3000);
        await Click(_policyDealNextButtonPath);
        await Task.Delay(3000);
        await Click(_policyDealNextButtonPath);
        await Task.Delay(3000);
        await Click(_policyDealPreviousButtonPath);
        await Task.Delay(3000);
        await Click(_policyDealNextButtonPath);
        await Task.Delay(3000);
        await Click(_policyDealPaymentDropdownPath);
        await Click(_policyDealPaymentDropdownPrintOrderButtonPath);
        await Task.Delay(2000);
        for (int i = 0; i < 3; i++)
        {
            Click(_policyDealPaymentPrintButtonModalPath);
            await Task.Delay(3000);
        }
        await Click(_policyDealPaymentCloseButtonModalPath);
        await Click(_policyDealNextButtonPath);
        await Task.Delay(3000);
        await Click(_policyDealFinishButtonPath);
        await Task.Delay(4000);
    }
}