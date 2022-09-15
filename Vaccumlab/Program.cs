using System.Text.Json;
using Vaccumlab.Implementations;
CancellationTokenSource source = new CancellationTokenSource();

string? path = String.Empty;
do
{
    Console.WriteLine("Provide path to the json file");
    path = Console.ReadLine();
}
while(string.IsNullOrWhiteSpace(path));

path = path.Trim();
var solver = new ChildSpeakerSolver();

await using var jsonStream = new FileStream(path, new FileStreamOptions()
{
    Access = FileAccess.Read,
    Mode = FileMode.Open,
    Options = FileOptions.Asynchronous
});
var json = await JsonSerializer.DeserializeAsync<IEnumerable<string>>(jsonStream);
if (json is null)
{
    Console.Error.WriteLine("Empty json file, exit");
    return;
}
var items = json as string[] ?? json.ToArray();
if (!items.Any())
{
    Console.Error.WriteLine("Empty json file, exit");
    return;
}

var outputs = await  solver.Solve(items, source.Token);

await File.WriteAllLinesAsync("output.out", outputs.Select(o => o.ToString()));
