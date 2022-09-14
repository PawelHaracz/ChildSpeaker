namespace Vaccumlab.Contracts;
using DataTransformObjects;
public interface IChildSpeakerSolver
{
    Task<IEnumerable<SolverOutputs>> Solve(IEnumerable<string> words, CancellationToken token = default);
}