using Geronimus.Core.Model;

namespace Geronimus.Core.Methods
{
    public abstract class AbstractMethod
    {
        public LinearSystem System { get; protected set; }
        public double ErrorRate { get; protected set; }

        public AbstractMethod()
        {
            this.System = new LinearSystem();
        }

        public abstract LinearSystemResult SolveIt();
        public virtual AbstractMethod AddEquation (LinearEquation equation)
        {
            this.System.Equations.Add(equation);
            return this;
        }
        public virtual AbstractMethod AddErrorRate(double errorRate)
        {
            this.ErrorRate = errorRate;
            return this;
        }
    }
}
