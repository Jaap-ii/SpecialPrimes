using System.Collections.Generic;
using System.Linq;

namespace SpecialPrimes
{
    public class Test
    {
        public int from { get; set; }
        public int to { get; set; }
        public List<int> results { get; set; }

        public bool VerifyResults(List<int> answer)
        {
            if (results == null && answer.Count == 0)
            {
                return true;
            }
            if (answer.Count != results.Count)
            {
                return false;
            }

            return answer.All(i => results.Contains(i));
        }
    }
}