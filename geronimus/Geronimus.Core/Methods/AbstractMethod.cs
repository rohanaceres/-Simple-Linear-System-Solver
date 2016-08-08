using Geronimus.Core.Model;

namespace Geronimus.Core.Methods
{
    public abstract class AbstractMethod
    {
        public LinearSystem System { get; protected set; }
        public decimal ErrorRate { get; protected set; }

        public abstract LinearSystemResult SolveIt();
        public virtual AbstractMethod AddEquation (LinearEquation equation)
        {
            this.System.Equations.Add(equation);
            return this;
        }
        public virtual AbstractMethod AddErrorRate(decimal errorRate)
        {
            this.ErrorRate = errorRate;
            return this;
        }
    }
}
