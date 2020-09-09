using System;
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
            //if (answer.Count != results.Count)
            //{
            //    return false;
            //}
            var answerNotresults = answer.Except(results).ToList();
            if (answerNotresults.Any()) 
                Console.WriteLine($"Wrong answers: {String.Join(",", answerNotresults.Take(10))}");
            var resultsNotanswer = results.Except(answer).ToList();
            if (resultsNotanswer.Any()) 
                Console.WriteLine($"Missing answers: {String.Join(",", resultsNotanswer.Take(10))}");
            return !answerNotresults.Any() && !resultsNotanswer.Any();
            return answer.All(i => results.Contains(i));
        }
    }
}