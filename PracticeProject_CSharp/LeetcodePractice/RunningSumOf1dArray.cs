using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPractice.LeetcodePractice
{
    public class RunningSumOf1dArray
    {
        public int[] RunningSum(int[] nums)
        {
            var result = new int[nums.Length];
            for(var index=0; index<nums.Length; index++)
            {
                result[index] = CalculateSum(nums, index);
            }
            return result;
        }

        private int CalculateSum(int[] nums, int index)
        {
            var sum = 0;
            for(var i=0; i<= index; i++)
            {
                sum += nums[i];
            }
            return sum;
        }
    }
}
