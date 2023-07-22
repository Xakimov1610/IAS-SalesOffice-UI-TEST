namespace IAS_SalesOffice_UI_TEST;

public partial class SalesOfficeTests
{
     /*      Paymetn 
        1 - Payments pageni ochish       ✔
        2 - Dropdownni bosib paymentni ko'rish va dealiga borish     ✔
        3 - Payments pageni yana ochib Global searchdan 'Sum' ni tanlab 56,000.00 bilan qidirish   ✔
        4 - Dropdownni bosib paymentni ko'rish va dealiga borish     ✔
        5 - Global 'Filter' buttonni bosib, 'Invoiced' radio ni tanlab, 'Start date' ni '01.07.2023' ni tanlab 'Period' buttonni bosish   ✔
        6 - Dropdownni bosib paymentni ko'rish va dealiga borish     ✔
        7 - Dealida 3-chiziqcha ni Details ni bosish 
     */
    
    public async Task PaymentTest()
    {
        
      //   var wait = SignInToSystem("https://sales.aic.uz", 20);
      await Click(_menuSalesFolderPath);

      await Click(_menuPaymentsPath);
      await Task.Delay(5000);
      
      await Click(_dropdownButtonPath);
      await Click(_paymentViewButtonPath);
      
      await Task.Delay(3000);
      
      await Click(_modalXButtonPath);
      await Click(_dropdownButtonPath);
      await Click(_goToDealButtonPath);
      await Task.Delay(3000);
      await Click(_menuPaymentsPath);
      
      await Task.Delay(5000);
      
      await Click(_globalSearchDropdownPath);
      await Click(_globalSearchSumColumnPath);
      
      await SendKey(_globalSearchInputPath, "56,000.00");
      await Click(_globalSearchButtonPath);
      await Task.Delay(3000);
      
      await Click(_dropdownButtonPath);
      await Click(_paymentViewButtonPath);
      
      await Task.Delay(3000);
      
      await Click(_modalXButtonPath);
      
      await Click(_globalFilterButtonPath);
      await Click(_invoicedRadioButtonPath);
      await Click(_startDateInputPeriodModalPath);
      await Click(_startDateValuePath);
      await Click(_periodButtonOnModalPath);
      
      await Task.Delay(4000);
      
      
      await Click(_dropdownButtonPath);
      await Click(_paymentViewButtonPath);
      
      await Task.Delay(3000);
      
      await Click(_modalXButtonPath);
      await Click(_dropdownButtonPath);
      await Click(_goToDealButtonPath);
      await Task.Delay(5000);
      
      await Click(_paymentDealDropdownPath);
      await Click(_paymentDealDropdownDetailsButtonPath);
      await Task.Delay(5000);
      
      await Click(_paymentDealObjectNextButtonPath);
      await Task.Delay(5000);
      await Click(_paymentDealContractStepButtonPath);
      await Task.Delay(5000);
      await Click(_paymentDealObjectNextButtonPath);
      await Task.Delay(5000);
      await Click(_paymentDealPreviousButtonPath);
      await Task.Delay(5000);
      await Click(_paymentDealPreviousButtonPath);
      await Task.Delay(5000);
      await Click(_paymentDealPaymentStepButtonPath);
      await Task.Delay(5000);
      await Click(_paymentDealObjectNextButtonPath);
      await Task.Delay(5000);
        
    }
}