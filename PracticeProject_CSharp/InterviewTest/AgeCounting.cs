using System.IO;
using System.Net;

namespace InterviewTest
{
    class AgeCounting
    {
        /*
         * Csharp Age Counting
         * In the C# file, write a program to perform a GET request on the route 
         * https://coderbyte.com/api/challenges/json/age-counting 
         * which contains a data key and the value is a string which contains items in the format: key=STRING, age=INTEGER. 
         * Your goal is to count how many items exist that have an age equal to or greater than 50, and print this final value.
         * 
         * Example Input
         * {"data":"key=IAfpK, age=58, key=WNVdi, age=64, key=jp9zt, age=47"}
         * 
         * Example Output
         * 2
         * 
         */

        public static int CleanJsonContent()
        {
            var request = WebRequest.Create("https://coderbyte.com/api/challenges/json/age-counting");
            var response = request.GetResponse();
            using (var dataStream = response.GetResponseStream())
            {
                var reader = new StreamReader(dataStream);
                var responseFromServer = reader.ReadToEnd();

                var count = 0;
                var content = responseFromServer.Split(':');
                foreach(var item in content[1].Split(','))
                {
                    var parts = item.Split('=');
                    if (parts[0].Replace(" ", "").Equals("age") 
                        && int.Parse(parts[1].Replace("\"}", "")) > 50 )
                    {
                            count++;
                    }
                }
                return count;
            }
        }
    }
}
