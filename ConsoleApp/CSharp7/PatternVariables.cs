using System;

namespace ConsoleApp.CSharp7
{
    public class PatternVariables
    {
        public static void Example1()
        {
            PrintIfString(new { Message = "It shouldn't be printed because it's anonimous class object"});
            PrintIfString("It should be printed because it's string!");

            void PrintIfString(object obj)
            {
                if (obj is string str)
                    Console.WriteLine(obj);
            }
        }

        public static void Example2()
        {
            var results = GetSomeResults();

            foreach(var result in results)
            {
                switch (result)
                {
                    case int i:
                        Console.WriteLine("It's an int.");
                        break;
                    case string s:
                        Console.WriteLine("It's a string.");
                        break;
                    case DateTime dateTime when dateTime < DateTime.Now:
                        Console.WriteLine("Its a datetime from the past");
                        break;
                    case DateTime dateTime when dateTime > DateTime.Now:
                        Console.WriteLine("Its a datetime from the future");
                        break;
                    case null:
                        Console.WriteLine("It's null");
                        break;
                }
            }
        }

        private static object[] GetSomeResults()
        {
            object[] values = new object[] { 12, "some string", DateTime.Now.AddDays(10), null };
            return values;
        }
    }
}
