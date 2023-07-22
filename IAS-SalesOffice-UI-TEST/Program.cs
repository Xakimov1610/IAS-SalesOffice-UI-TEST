using IAS_SalesOffice_UI_TEST;

try
{
	var test = new SalesOfficeTests();
	await test.SignInToSystem("https://sales.aic.uz/");

	while (true)
	{
		Console.WriteLine("started");
		await test.RunTests();
		Console.WriteLine("finished");
	}
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
	Console.WriteLine("/n");
	Console.WriteLine(ex.ToString());
}