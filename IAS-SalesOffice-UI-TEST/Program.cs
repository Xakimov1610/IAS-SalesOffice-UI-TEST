using IAS_SalesOffice_UI_TEST;

try
{
	Console.WriteLine("started");
	var test = new SalesOfficeTest();
	test.RunMultiTab(3);
	Console.WriteLine("finished");
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
	Console.WriteLine("/n");
	Console.WriteLine(ex.ToString());
}