using System.Text.RegularExpressions;

namespace InterviewTest
{
    public class SnakeCase
    {
        /*
         * Have the function SnakeCase(str) take the str parameter being passed 
         * and return it in proper snake case format 
         * where each word is lowercased and separated from adjacent words via an underscore. 
         * The string will only contain letters and some combination of delimiter punctuation characters separating each word.
         * 
         * For example: if str is "BOB loves-coding" then your program should return the string bob_loves_coding.
         * 
         * Examples
         * Input: "cats AND*Dogs-are Awesome"
         * Output: cats_and_dogs_are_awesome
         * Input: "a b c d-e-f%g"
         * Output: a_b_c_d_e_f_g 
         */

        public static string TransformSnakeCase(string str)
        {
            var result = string.Empty;
            var pattern = @"[a-zA-Z]+";
            var rex = new Regex(pattern);
            foreach(Match match in rex.Matches(str))
            {
                result += match.Value.ToLower() + "_";
            }

            if (result.Length > 0)
                return result.Substring(0, result.Length - 1);

            return string.Empty;
        }
    }
}
