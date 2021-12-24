using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaClauseConsoleApp
{
    public class Ui
    {
        public Ui()
        {

        }
        public void PrintItem(Item a)
        {
            Console.WriteLine(a.Id + " " + a.Name);

        }

        public void PrintChild(Child a)
        {
            Console.WriteLine("Child Name: " + a.Name);
            if(a.DateOfBirth.Year==new DateTime().Year)
                Console.WriteLine("Child birthdate: not sure, sometime around " + (DateTime.Now.Year-a.Age) );
            else
                Console.WriteLine("Child birthdate: "+ a.DateOfBirth);
            Console.WriteLine("Child address: " + a.Address);
            Console.WriteLine("Child wants: ");
            foreach(var i in a.Letter.Gifts)
                Console.Write(i.Name+" ");
            Console.WriteLine();
            Console.WriteLine("Was he nice? " + (a.IsNice ? "yes" : "no") );
            Console.WriteLine("\n------------------------------------------------------------------------------------\n");
        }

        public void PrintChildren(List<Child> childList)
        {
            foreach (var item in childList)
            {
                PrintChild(item);
            }
        }

        public void PrintReport(IOrderedEnumerable<KeyValuePair<string, int>> report)
        {
            foreach(var item in report)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }

        public void PrintItinerary(Dictionary<string,List<string>> itinerary)
        {
            foreach(var item in itinerary)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine();
                 foreach(var address in item.Value)
                {
                    Console.WriteLine("   -" + address);
                }
                Console.WriteLine();
            }
        }
    }
}