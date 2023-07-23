using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace IAS_SalesOffice_UI_TEST;

public partial class SalesOfficeTests
{
	public IWebDriver edgeDriver;
	public WebDriverWait wait;

	#region Basic Authorization

	private readonly By _usernamePath = By.XPath("//*[@id=\"username\"]");
	private readonly By _passwordPath = By.XPath("//*[@id=\"password\"]");
	private readonly By _signInButtonPath = By.XPath("/html/body/div[3]/div[3]/div[2]/div/div/div/div/form/button");

	private readonly By _selectSellerInputPath = By.XPath("//*[@id=\"menu-exp\"]/div[2]/div/div/div/input");
	private readonly By _selectSellerPath = By.XPath("//*[@id=\"menu-exp\"]/div[2]/div/div/div[2]");
	private readonly By _selectButtonPath = By.XPath("/html/body/div[2]/button");

	#endregion

	#region All PageLoader Test Paths
	
	private readonly By _allMenuSales_Path = By.XPath("/html/body/div[4]/div[2]/ul/li[3]/a/span");
	private readonly By _allDeals_Path = By.XPath("/html/body/div[4]/div[2]/ul/li[3]/ul/li[1]/a");
	private readonly By _allInvoice_Path = By.XPath("/html/body/div[4]/div[2]/ul/li[3]/ul/li[2]/a");
	private readonly By _allPayments_Path = By.XPath("/html/body/div[4]/div[2]/ul/li[3]/ul/li[3]/a");
	private readonly By _allBankPayment_Path = By.XPath("/html/body/div[4]/div[2]/ul/li[3]/ul/li[4]/a");
	private readonly By _allPolicies_Path = By.XPath("/html/body/div[4]/div[2]/ul/li[3]/ul/li[5]/a");
	private readonly By _allMenuProducts_Path = By.XPath("/html/body/div[4]/div[2]/ul/li[4]/a");
	private readonly By _allMenuBsr_Path = By.XPath("/html/body/div[4]/div[2]/ul/li[5]/a");
	private readonly By _allMenuSallerUsers_Path = By.XPath("/html/body/div[4]/div[2]/ul/li[6]/a");
	private readonly By _allMenuNumberBuking_Path = By.XPath("/html/body/div[4]/div[2]/ul/li[7]/a");
	private readonly By _allMenueReissue_Path = By.XPath("/html/body/div[4]/div[2]/ul/li[8]/a");
	private readonly By _allMenueDashbord_Path = By.XPath("/html/body/div[4]/div[2]/ul/li[2]/a");
	

	#endregion

	#region Download Portfolo Test Paths
	
	private readonly By _menuSalesFolderPath = By.XPath("//*[@id=\"main-menu-navigation\"]/li[3]/a");
	private readonly By _menuSalesPath = By.XPath("//*[@id=\"main-menu-navigation\"]/li[3]/ul/li[1]/a");

	private readonly By _downloadPortfolioButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[1]/div/div[2]/div[2]/button[2]");
	private readonly By _startDateInputPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[7]/div/div/div[2]/input[2]");
	private readonly By _startDateSelectorPath = By.XPath("/html/body/div[7]/div[2]/div/div[2]/div/span[6]");
	private readonly By _downloadButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[7]/div/div/div[3]/button[2]");
	#endregion

	#region Invoive Test Paths

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

	#region Travel Test Paths

	private readonly By _createDealButton = By.XPath("/html/body/nav/div/ul/div[1]/li");
    private readonly By _createTravelClick = By.XPath("/html/body/nav/div/ul/div[1]/div/a[1]");
    private readonly By _travelCountryInput = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div/div[1]/div/div[1]/input");
    private readonly By _clickCountry = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div/div[1]/div[2]/div");
    private readonly By _startDateInput = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/input[2]");
    private readonly By _startDateDay = By.XPath("/html/body/div[10]/div[2]/div/div[2]/div/span[29]");
    private readonly By _endDateInput = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[2]/input[2]");
    private readonly By _endDateDay = By.XPath("/html/body/div[11]/div[2]/div/div[2]/div/span[35]");
    private readonly By _programInput = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[1]/div[2]/div[3]/div[1]/div/div/div[2]");
    private readonly By _programInputClick = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[1]/div[2]/div[3]/div[1]/div/div[2]/div[5]");

    private readonly By _dateOfBirthInput = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/input[2]");
    private readonly By _passSeriaInput = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[3]/div/input[1]");
    private readonly By _passNumberInput = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[3]/div/input[2]");
    private readonly By _searchPersonButton = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[5]/button[1]");
    private readonly By _personContactInput = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[3]/div[2]/div[3]/div[2]/input");
    private readonly By _policyBankPay = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[4]/div[2]/div[1]/div/div[3]/select/option[2]");
    private readonly By _payButton = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[4]/div[2]/div[1]/div/div[4]/div/button");
    private readonly By _confirmationButton = By.XPath("/html/body/div[6]/div[3]/div[1]/div[14]/div/div/div[3]/button[1]");
    private readonly By _travelFinishButton = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[2]/div[2]/button[2]");

	#endregion

	#region Payment Test Paths
	
	private readonly By _menuPaymentsPath = By.XPath("/html/body/div[4]/div[2]/ul/li[3]/ul/li[3]/a/span");

    private readonly By _dropdownButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[13]/div/div/button");
    private readonly By _paymentViewButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[13]/div/div/div/a[2]");
    private readonly By _modalXButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[4]/div/div/div[1]/button");
    private readonly By _goToDealButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[13]/div/div/div/a[1]");
    private readonly By _globalSearchInputPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[1]/div/div[1]/div/div/input");
    private readonly By _globalSearchButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[1]/div/div[1]/button");
    private readonly By _globalSearchDropdownPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[1]/div/div[1]/div/div/select");
    private readonly By _globalSearchSumColumnPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[1]/div/div[1]/div/div/select/option[5]");
    
    private readonly By _globalFilterButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[1]/div/div[2]/div/button");
    private readonly By _invoicedRadioButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[6]/div/div/div[2]/div/div/div[2]/input");
    private readonly By _startDateInputPeriodModalPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[6]/div/div/div[2]/input[2]");
    private readonly By _startDateValuePath = By.XPath("/html/body/div[12]/div[2]/div/div[2]/div/span[6]");
    private readonly By _periodButtonOnModalPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[6]/div/div/div[3]/button[2]");
    private readonly By _paymentDealDropdownPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/button");
    private readonly By _paymentDealDropdownDetailsButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/a[1]");
    private readonly By _paymentDealContractStepButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div/ul/a[3]");
    private readonly By _paymentDealPaymentStepButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div/ul/a[5]");
    private readonly By _paymentDealObjectNextButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div/div[3]/button[2]");
    private readonly By _paymentDealPreviousButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div/div[3]/button[1]");
    private readonly By _paymentDealPaymentDropdownPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[2]/div[3]/div[1]/div[2]/table/tbody/tr/td[7]/div/div/button");
    private readonly By _paymentDealPaymentPrintOrderButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[2]/div[3]/div[1]/div[2]/table/tbody/tr/td[7]/div/div/div/a[2]");
    private readonly By _paymentDealPaymentPrintButtonModalPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[2]/div[3]/div[2]/div[1]/div/div[3]/button[1]");
    private readonly By _paymentDealPaymentCloseButtonModalPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div[2]/div[3]/div[2]/div[1]/div/div[3]/button[2]");
	
	#endregion

	#region Policy Test Paths

	private readonly By _menuPoliciesPath = By.XPath("/html/body/div[4]/div[2]/ul/li[3]/ul/li[5]/a");
    private readonly By _policyDropdownButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[11]/div/div/button");
    private readonly By _policyGoToDealButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[11]/div/div/div/a[1]");
    private readonly By _policyViewButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[11]/div/div/div/a[2]");
    private readonly By _policyModalCloseButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[4]/div/div/div[3]/button");
    private readonly By _policyStatusButtonDropdownPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[1]/div[1]/div[1]/div/div/select/option[8]");
    private readonly By _policyDealEditButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[2]/div/button[2]");
    private readonly By _policyDealNextButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[2]/div[2]/button[2]");
    private readonly By _policyDealPreviousButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[2]/div[2]/button[1]");
    private readonly By _policyDealFinishButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[2]/div/div[2]/div[3]/button[2]");
    private readonly By _policyDealPaymentDropdownPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[3]/div[1]/div[2]/table/tbody/tr/td[7]/div/div/button");
    private readonly By _policyDealPaymentDropdownPrintOrderButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[3]/div[1]/div[2]/table/tbody/tr/td[7]/div/div/div/a[2]");
    private readonly By _policyDealPaymentPrintButtonModalPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[3]/div[2]/div[1]/div/div[3]/button[1]");
    private readonly By _policyDealPaymentCloseButtonModalPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[3]/div[2]/div[1]/div/div[3]/button[2]");

	#endregion

	#region BSR Test Paths

	private readonly By _menuBSRPath = By.XPath("/html/body/div[4]/div[2]/ul/li[6]/a");
    private readonly By _exportExcelButton = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/button");
    private readonly By _distributionButton = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/ul/li[2]/button");
    private readonly By _returnButton = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/ul/li[3]/button");
    private readonly By _requestsButton = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/ul/li[4]/button");
    private readonly By _aquireDropdownView = By.XPath("/html/body/div[6]/div[3]/div[1]/div[2]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[10]/div/div/button");
    private readonly By _aquireButtonView = By.XPath("/html/body/div[6]/div[3]/div[1]/div[2]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[10]/div/div/div/a");
    private readonly By _aquireViewClose = By.XPath("/html/body/div[6]/div[3]/div[1]/div[2]/div[6]/div/div/div[2]/button");
    private readonly By _returnRequestButton = By.XPath("/html/body/div[6]/div[3]/div[1]/div[2]/ul/a[2]");
    private readonly By _returnRequestViewDropdown = By.XPath("/html/body/div[6]/div[3]/div[1]/div[2]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[10]/div/div/button");
    private readonly By _returnRequestViewButton = By.XPath("/html/body/div[6]/div[3]/div[1]/div[2]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[10]/div/div/div/a");
    private readonly By _returnRequestCloseButton = By.XPath("/html/body/div[6]/div[3]/div[1]/div[2]/div[6]/div/div/div[2]/button");
    private readonly By _stateChangeButton = By.XPath("/html/body/div[6]/div[3]/div[1]/div[2]/ul/a[3]");
    private readonly By _stateChangeViewDropdown = By.XPath("/html/body/div[6]/div[3]/div[1]/div[2]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[8]/div/div/button");
    private readonly By _stateChangeViewButton = By.XPath("/html/body/div[6]/div[3]/div[1]/div[2]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[8]/div/div/div/a");
    private readonly By _stateChangeCloseButton = By.XPath("/html/body/div[6]/div[3]/div[1]/div[2]/div[4]/div[2]/form/div/div[7]/button");

	#endregion

	#region OSGOVTS Test Paths

	private readonly By _createDealButtonPath = By.XPath("/html/body/nav/div/ul/div[1]/li");
    private readonly By _osgovtsButtonPath = By.XPath("/html/body/nav/div/ul/div[1]/div/a[2]");
    private readonly By _gosNumberPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[1]/div[1]/div[2]/div/div/div[1]/input");
    private readonly By _techPassSerPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[1]/div[1]/div[2]/div/div/div[2]/div/input");
    private readonly By _techPassNumPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[1]/div[1]/div[2]/div/div/div[3]/div/input");
    private readonly By _searchButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[1]/div[1]/div[2]/div/div/button[1]");
    private readonly By _nextButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[2]/div[2]/button[2]");
    private readonly By _addButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[2]/div/div[2]/div/button[2]");
    private readonly By _dateOfBirthPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[2]/div/div[2]/div[1]/div[1]/div[1]/input[2]");
    private readonly By _passportSerPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[2]/div/div[2]/div[1]/div[1]/div[2]/div/input[1]");
    private readonly By _passportNumPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[2]/div/div[2]/div[1]/div[1]/div[2]/div/input[2]");
    private readonly By _pinflPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[2]/div/div[2]/div[1]/div[1]/div[3]/input");
    private readonly By _generateInvoicePath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[3]/div[1]/div[2]/div/button");
    private readonly By _createInvoicePath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[3]/div[4]/div/div/div[3]/button[1]");
    private readonly By _actionButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[3]/div[1]/div[2]/table/tbody/tr/td[7]/div/div");
    private readonly By _payButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[3]/div[1]/div[2]/table/tbody/tr/td[7]/div/div/div/a[4]");
    private readonly By _bankConPayButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[3]/div[3]/div/div/div/ul/a[1]");
    private readonly By _setPayedButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[3]/div[3]/div/div/div[3]/button[1]");
    private readonly By _osgovtsCloseButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div[1]/div/div[3]/div[3]/div/div/div[3]/button[2]");
    private readonly By _dealButtonPath = By.XPath("/html/body/div[4]/div[2]/ul/li[3]/ul/li[1]/a");
    private readonly By _dealActionButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[17]/div/div");
    private readonly By _dealViewButtonPath = By.XPath("/html/body/div[6]/div[3]/div[1]/div[1]/div/div/div[2]/div[1]/div[2]/table/tbody/tr[1]/td[17]/div/div/div/a[1]");
    private readonly By _dashboardButtonPath = By.XPath("/html/body/div[4]/div[2]/ul/li[2]/a/span");

	#endregion


	#region Const Values

	private const string _username = "oakrom";
	private const string _password = "123456789";
	private const string _siteUrl = "https://sales.aic.uz";
	private const int _waitingSecond = 20;
	private const int _shortDelay = 4000;
	private const int _mediumDelay = 8000;
	private const int _longDelay = 10000;
	// private const string _username = "n.xakimov";
	// private const string _password = "654321";
	private const string _sellerName = "Head office";
	private const string _statusAction = "Closed";
	private const string _country = "TURKEY";
	private const string _travelPersonPhone = "998941112233";
	private const string _travelDateBirth = "20.04.1989";
	private const string _travelPassSeria = "AB";
	private const string _travelPassNumber = "0662147";
	
	private const string _gosnumber = "01978KHA";
	private const string _techpasser = "AAF";
	private const string _techpassnumber = "2380903";
	private const string _dateOfBirth = "24.04.2003";
	private const string _passportSer = "AC";
	private const string _passportNum = "1871799";


	#endregion

	public SalesOfficeTests()
	{
		edgeDriver = new EdgeDriver();
		wait = new WebDriverWait(edgeDriver, TimeSpan.FromSeconds(120));
	}

	// public async Task RunMultiTab(int tabCount)
	// {
	// 	for (int i = 1; i <= tabCount; i++)
	// 	{
	// 		((IJavaScriptExecutor)edgeDriver).ExecuteScript("window.open();");
	// 	}
	//
	// 	List<Task> tasks = new();
	// 	foreach (var handle in edgeDriver.WindowHandles)
	// 	{
	// 		tasks.Add(RunTests(handle));
	// 	}
	//
	// 	await Task.WhenAll(tasks);
	// }

	public async Task RunTests()
	{
		// await InvoiceTest();
		// await TravelTest();
		//await DownloadPortfolioTest();
		await AllPageLoadTest();
		// await InvoiceTest();
		// await TravelTest();
		// await BSRTest();
		// await PaymentTest();
		// await PolicyTest();
		
		await Task.Delay(_mediumDelay);
	}
}
