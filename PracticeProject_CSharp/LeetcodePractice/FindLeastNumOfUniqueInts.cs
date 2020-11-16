using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPractice.LeetcodePractice
{
    public class FindLeastNumOfUniqueInts
    {
        public int FindLeastUniqueInts(int[] arr, int k)
        {
            var numberCount = arr.AsQueryable()
                .GroupBy(x => x)
                .Select(number => number.Count())
                .OrderBy(item => item)
                .ToList();

            var cutTimes = 0;
            var cutAmount = 0;
            while (cutTimes < numberCount.Count() 
                && cutAmount + numberCount[cutTimes] <= k)
            {
                cutAmount += numberCount[cutTimes];
                cutTimes +=1;
            }
            return arr.Distinct().Count() - cutTimes;
        }
    }
}
