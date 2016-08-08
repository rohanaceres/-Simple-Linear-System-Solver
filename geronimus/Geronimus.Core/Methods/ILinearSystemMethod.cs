namespace Geronimus.Core.Methods
{
    public interface ILinearSystemMethod
    {
        LinearSystemResult SolveIt(LinearSystem linearSystem);
    }
}
