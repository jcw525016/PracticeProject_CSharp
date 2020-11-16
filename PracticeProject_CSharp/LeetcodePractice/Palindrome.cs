using System;

namespace LeetcodePractice
{
    public class Palindrome
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0 || x > Int32.MaxValue)
                return false;

            if (x >= 0 && x < 10)
                return true;

            var times = Convert.ToInt32(Math.Log10(x) / 2);
            times = times == 0 ? 1 : times;
            var leftShiftNum = x;
            var rightShiftNum = x;
            var level = (int)Math.Pow(10, (int)Math.Floor(Math.Log10(leftShiftNum)));

            for (int i = 0; i < times; i++)
            {
                var firstDigit = (int)leftShiftNum / level;
                var lastDigit = rightShiftNum % 10;
                if (firstDigit != lastDigit)
                    return false;

                leftShiftNum -= (firstDigit * level);
                rightShiftNum /= 10;
                level /= 10;
            }

            return true;
        }
    }
}