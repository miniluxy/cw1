using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    class Program
    {

        public static string URL = "https://www.pja.edu.pl/";


        //public static async Task<string> Main - <string> zwraca string
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (HttpClient httpClient = new HttpClient())
            {
                using (var responde = await httpClient.GetAsync(args[0]))
                {
                    Console.WriteLine(responde.ToString());//frame
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine(await responde.Content.ReadAsStringAsync()); //Zawartość strony
                    Regex regex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
                    Regex regex2 = new Regex("[a-z]+[a-z0-9]+\\.[a-z]", RegexOptions.IgnoreCase);
                    MatchCollection emailMatches = regex.Matches(await responde.Content.ReadAsStringAsync());


                    Console.WriteLine("All mails:");
                    foreach (Match match in emailMatches)
                        Console.WriteLine(match.ToString());
                }
            }



            //HttpClient httpClient = new HttpClient();

            var newPerson = new Person(); //pusty
            var newPerson2 = new Person { FirstName = "Janusz" };


            //var path = @"c:\User\cw1"; @ - dzieki temu nie trzeba wstawaić backslash
            //string tmp1 = "Ala", tmp2 = "ma";
            //Console.WriteLine($"{tmp1} {tmp2}"); $ - dzieki temu nie potrzeba +
            //Regex regex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);




            //dotnet run https://www.pja.edu.pl/
        }
    }
}


