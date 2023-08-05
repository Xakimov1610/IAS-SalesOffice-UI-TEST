using IAS_SalesOffice_UI_TEST;

var tasks = new List<Task>();
for (int i = 0; i < 10; i++)
{
	var test = new SalesOfficeTests();
	await test.SignInToSystem("https://sales.aic.uz/");
	tasks.Add(Runner(test));
}
await Task.WhenAll(tasks);



static async Task Runner(SalesOfficeTests test)
{
	while (true)
	{
		Console.WriteLine($"Started : {DateTime.Now}");
		try
		{
			await test.RunTests();
		}
		catch (Exception e)
		{
			// IsRunnerException = true;
			Console.WriteLine($"Started new : {DateTime.Now} / message : {e.Message}");
			await test.RunTests();
		}
		Console.WriteLine("finished");
	}
}