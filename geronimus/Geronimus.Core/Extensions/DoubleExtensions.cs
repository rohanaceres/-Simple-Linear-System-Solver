namespace Geronimus.Core.Extensions
{
    public static class DoubleExtensions
    {
        public static double Invert(this double self)
        {
            return self * -1;
        }
        public static double InvertIfNegative(this double self)
        {
            if (self < 0)
            {
                return self.Invert();
            }

            return self;
        }
    }
}
