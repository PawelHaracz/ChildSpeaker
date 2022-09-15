namespace Vaccumlab.DataTransformObjects;

public record SolverOutputs(string Word, long Count)
{
    public override string ToString() 
        => $"{Word} {Count}";

    public static SolverOutputs Default = new(string.Empty, 0);
}