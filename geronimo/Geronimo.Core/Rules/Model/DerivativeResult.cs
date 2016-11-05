namespace Geronimo.Core.Rules.Model
{
    public sealed class DerivativeResult
    {
        public double Result { get; set; }
        public double RelativeError { get; set; }
        public string RelativeErrorPercentage { get; set; }
    }
}
