namespace Vaccumlab.Implementations;
using Models;
using Contracts;
using DataTransformObjects;

internal class ChildSpeakerSolver : IChildSpeakerSolver
{
    private readonly IChildSpeaker _speaker;
    public ChildSpeakerSolver()
    {
        _speaker = new ChildSpeaker();
    }
    
    public async Task<IEnumerable<SolverOutputs>> Solve(IEnumerable<string> words, CancellationToken token = default)
    {
        var deduplicate = words.Distinct();
        var tasks = deduplicate.Select(w => Task.Run(() => new ChildSpeakerOutputs(w, _speaker.Process(w)), token));

        var results = await Task.WhenAll(tasks);
        
        var dictionary = new Dictionary<string, int>();
        var countDictionary = new Dictionary<string, int>();
        foreach (var result in results)
        {
            var counts = 0;
            if (!countDictionary.ContainsKey(result.Translation))
            {
                counts = results.Count(r => r.Translation == result.Translation);
                countDictionary.Add(result.Translation, counts);
            }

            counts = countDictionary[result.Translation];
            dictionary.Add(result.Word, counts - 1);
        }

        var outputs =  dictionary
            .Select(pair => new SolverOutputs(pair.Key, pair.Value))
            .Where(s => s != SolverOutputs.Default)
            .OrderBy(r=> r.Word);
        return outputs;
        
        //A lot allocations below
        // var grouped = results.GroupBy(outputs => outputs.Translation)
        //     .Select(g => 
        //         new
        //         {
        //             Key = g.Key, 
        //             Count = g.Count()
        //         });
        //
        // var outputs = results
        //     .Select(r =>
        //         {
        //             var word = r.Word;
        //             var countTranslation = grouped.SingleOrDefault(arg => arg.Key == r.Translation)!.Count;
        //             if (countTranslation > 0)
        //             {
        //                 countTranslation = countTranslation - 1;
        //             }
        //             else
        //             {
        //                 countTranslation = 0;
        //             }
        //             return new SolverOutputs(word, countTranslation);
        //         }
        //     )
        //     .OrderBy(r => r.Word);

        //return outputs;
    }
}