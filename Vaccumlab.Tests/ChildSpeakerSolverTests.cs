namespace Vaccumlab.Tests;
using System.Threading.Tasks;
using Xunit;
using Contracts;
using Implementations;

public class ChildSpeakerSolverTests
{

    private readonly IChildSpeakerSolver _solver = new ChildSpeakerSolver();
    
    [Fact]
    public async Task add_sample_inputs_should_solve_it()
    {
        var arrange = new[] { "mapa", "alan", "island", "lampa", "lajdak", "alan", "mama" };

        var act = await _solver.Solve(arrange);
        
        Assert.Collection(act, outputs =>
            {
                Assert.Equal("alan", outputs.Word);
                Assert.Equal(2, outputs.Count);
            },
            outputs =>
            {
                Assert.Equal("island", outputs.Word);
                Assert.Equal(0, outputs.Count);
            },
            outputs =>
            {
                Assert.Equal("lajdak", outputs.Word);
                Assert.Equal(2, outputs.Count);
            },
            outputs =>
            {
                Assert.Equal("lampa", outputs.Word);
                Assert.Equal(2, outputs.Count);
            },
            outputs =>
            {
                Assert.Equal("mama", outputs.Word);
                Assert.Equal(1, outputs.Count);
            },
            outputs =>
            {
                Assert.Equal("mapa", outputs.Word);
                Assert.Equal(1, outputs.Count);
            }
            );
    }
}