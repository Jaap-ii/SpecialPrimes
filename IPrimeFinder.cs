namespace SpecialPrimes
{
    public interface IPrimeFinder
    {
        bool IsPrime(int n);
        void Init(int lowerbound, int upperbound);
    }
}