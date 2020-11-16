using System;
using System.Linq;

namespace LeetcodePractice
{
    public class ReverseInteger
    {
        public int ReverseInt(int x)
        {
            try
            {
                if (x <= Int32.MinValue || x > Int32.MaxValue)
                    return 0;

                var sign = x > 0 ? 1 : -1;
                x *= sign;
                var reverse = string.Concat(x.ToString().Reverse());
                int.TryParse(reverse, out int result);
                return checked(result * sign);
            }
            catch (System.OverflowException e)
            {
                return 0;
            }
        }
    }
}