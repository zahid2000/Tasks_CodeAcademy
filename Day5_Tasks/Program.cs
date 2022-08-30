using System.Diagnostics;


#region forma1
List<string> urls = new List<string>()
{
    "https://github.com/",
    "https://docs.microsoft.com/tr-tr/dotnet/api/system.collections.generic.sorteddictionary-2.enumerator?view=net-6.0",
    "https://docs.microsoft.com/tr-tr/learn/",
    "https://tr.n4zc.com/article/programming/c_sharp/2vvj5z7l.html",
    "https://www.tutorialspoint.com/entity_framework/entity_framework_code_first_approach.htm",
    "https://docs.microsoft.com/en-us/sql/relational-databases/json/json-data-sql-server?view=sql-server-ver16"
};

await GetHtmlAsync(urls);

static async Task GetHtmlAsync(List<string> urls)
{
    List<Task<string>> taskList = new List<Task<string>>();
    HttpClient client = new HttpClient();
    Stopwatch stopwatch = new Stopwatch();

    stopwatch.Start();
    foreach (string url in urls)
        taskList.Add(client.GetStringAsync(url));

    await Task.WhenAll(taskList);
    stopwatch.Stop();
    foreach (var task in taskList)
        Console.WriteLine($"{task.Result.Length} - {stopwatch.ElapsedMilliseconds} second");
}

#endregion
