using System;

namespace P0_KemoAllen
{
    class Program
    {
        static void Main(string[] args)
        {
            getTemperature();
        }
        public static void getTemperature()
        {
            bool temperatureParsed;
            int num;

            Console.WriteLine("Please enter a temperature between -40 and 130 degrees Fahrenheit.");
            string response = Console.ReadLine();
            temperatureParsed = int.TryParse(response, out num); 
            Console.WriteLine("You said the temperature was " + num);

            if(num <= 30){
                Console.WriteLine("Really cold");
            
            }
            else if(num <= 90){
                Console.WriteLine("Warm");
            }
            else{
                Console.WriteLine("Really hot");
            }
        }
    }
}
