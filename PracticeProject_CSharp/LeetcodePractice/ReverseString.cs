using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetcodePractice
{
    public class ReverseStringWithIndexK
    {
        public string ReverseStr(string s, int k)
        {
            var result = new List<char>();
            var interation = Convert.ToInt32(Math.Ceiling(s.Length / (2.0 * k)));
            var index = 1;

            while (index <= interation)
            {
                var head = 2 * k * (index - 1);

                var middle = head + k <= s.Length
                    ? head + k - 1
                    : head + s.Length % k - 1;

                var tail = head + (2 * k) <= s.Length
                    ? head + (2 * k) - 1
                    : head + s.Length % (2 * k) - 1;

                for (int i = middle; i >= head; i--)
                    result.Add(s[i]);

                for (int j = middle + 1; j <= tail; j++)
                    result.Add(s[j]);

                index++;
            }
            return string.Concat(result);
        }

        public string ReverseString(string s)
        {
            return string.Concat(s.Reverse());
        }
    }
}