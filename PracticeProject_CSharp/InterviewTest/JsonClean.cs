using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace InterviewTest
{
    class JsonClean
    {
        /*
         * Csharp JSON Cleaning
         * In the C# file, write a program to perform a GET request on the route 
         * https://coderbyte.com/api/challenges/json/json-cleaning 
         * and then clean the object according to the following rules: 
         *      Remove all keys that have values of N/A, -, or empty strings. 
         *      If one of these values appear in an array, remove that single item from the array. 
         *      Then console log the modified object as a string.
         *      
         *      Example Input
         *      {"name":{"first":"Daniel","middle":"N/A","last":"Smith"},"age":45}
         *      
         *      Example Output
         *      {"name":{"first":"Daniel","last":"Smith"},"age":45}
         */

        public static string CleanJsonContent()
        {
            var request = WebRequest.Create("https://coderbyte.com/api/challenges/json/json-cleaning");
            var response = request.GetResponse();
            using (var dataStream = response.GetResponseStream())
            {
                var reader = new StreamReader(dataStream);
                var responseFromServer = reader.ReadToEnd();
                var responseObkect = JsonConvert.DeserializeObject<Profile>(responseFromServer);
                foreach (var propertyInfo in responseObkect.GetType().GetProperties())
                {
                   // Unfinished
                }


                return responseFromServer;
            }
        }

        public class Name
        {
            public string first { get; set; }
            public string middle { get; set; }
            public string last { get; set; }
        }

        public class Education
        {
            public string highschool { get; set; }
            public string college { get; set; }
        }

        public class Profile
        {
            public Name name { get; set; }
            public int age { get; set; }
            public string DOB { get; set; }
            public List<string> hobbies { get; set; }
            public Education education { get; set; }
        }
    }
}
