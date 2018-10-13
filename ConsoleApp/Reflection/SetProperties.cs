using System;

namespace ConsoleApp.Reflection
{
    public class SetProperties
    {
        public static void Example1()
        {
            var country1 = new Country { Id = 234, Name = "France" };
            var country2 = new Country { Id = 7, Name = "England" };

            Console.WriteLine("Before: " + country2.ToString());

            var properties = country2.GetType().GetProperties();
            foreach(var property in properties)
            {
                var propertyValue = property.GetValue(country1);
                property.SetValue(country2, propertyValue);
            }

            Console.WriteLine("After: " + country2.ToString());
        }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString() => $"Id = {Id}, Name = {Name}";
    }
}
