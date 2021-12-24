using SantaClauseConsoleApp.Core;
using SantaClauseConsoleApp.Repository;
using SantaClauseConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
namespace SantaClauseConsoleApp
{
    class Program
    {
        static Ui console_ui = new();
        static ItemRepo ItemRepo = ItemRepo.Instance();
        static ItemService ItemService = ItemService.Instance(ItemRepo);
        static ChildRepo ChildRepo = ChildRepo.Instance();
        static ChildService ChildService = ChildService.Instance(ChildRepo);
        static LetterRepo LetterRepo = LetterRepo.Instance();
        static LetterService LetterService = LetterService.Instance(LetterRepo, ItemService);
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1\n //////////////////////////////////\n");
            Question1();
            Console.WriteLine("Question 2\n //////////////////////////////////\n");
            Question2();
            Question3();
            Console.WriteLine("Question 4\n //////////////////////////////////\n");
            Question4();
            Question5();
            Console.WriteLine("Question 6\n //////////////////////////////////\n");
            Question6();
        }

        static void Question1()
        {
            ItemService.Add("bycicle");
            ItemService.Add("toy car");
            ItemService.Add("keyboard");
            ItemService.Add("monitor");
            ItemService.Add("console");
            ItemService.Add("dinosaur");

            for (int i = 1; i <= 3; i++)  //creates 3 random letters
            {
                List<Item> random_list = new();
                int size = 2;
                for (int j = 0; j < size; j++)
                {
                    random_list.Add(ItemService.GetRandom());
                }
                LetterService.Add(random_list);
            }
            var date = new DateTime(2002, 12, 1);
            var address = new Address("Timisoara", "Strada Castanelor", 1);
            ChildService.Add("Mihai", date, 18, address, LetterRepo.GetPos(0), false);
            date = new DateTime(2002, 9, 3);
            address = new Address("Timisoara", "Strada Cascadaei", 17);
            ChildService.Add("Rares", date, 18, address, LetterRepo.GetPos(1), false);
            date = new DateTime(2001, 1, 1);
            address = new Address("Ploiesti", "Strada Verde", 60);
            ChildService.Add("Andrei", date, 18, address, LetterRepo.GetPos(2), false);

            console_ui.PrintChild(ChildRepo.GetPos(0));
            console_ui.PrintChild(ChildRepo.GetPos(1));
            console_ui.PrintChild(ChildRepo.GetPos(2));
        }

        static void Question2()
        {
            /*
             * finds all the letters in the Letters directory and reads them
             * for the porpouse of this questions and because of the lack of persistance
             * it only reads the 3 files requested in the problem statement
             */
            var letters = Directory.GetFiles(@"../../../Letters");

            foreach (var item in letters)
            {
                if (!item.Contains("question2"))
                    continue;
                string text = LetterService.ReadLetter(item);
                var info = LetterService.DeserializeLetter(text);
                LetterService.Add(info.Item4);
                ChildService.Add(info.Item1, new DateTime(), info.Item2, info.Item3, LetterService.GetLatestLetter(), info.Item5);
            }
            console_ui.PrintChildren(ChildRepo.ChildList);
        }

        static void Question3()
        {
            var list = ChildService.GetList();
            foreach (var item in list)
            {
                var text = LetterService.SerializeLetter(item);
                LetterService.SendLetter(item.Name + item.Letter.Id, text);
            }
        }

        static void Question4()
        {
            var report = ItemService.GenerateReport();
            console_ui.PrintReport(report);
        }

        static void Question5()
        {
            /*
             * Our program can be made to respect the singleton pattern since we can only use one instance of 
             * the service and repository classes, otherwise the data from memory would be lost
             */
        }

        static void Question6()
        {
            var result = ChildService.GenerateItinerary();
            console_ui.PrintItinerary(result);
        }
    }
}

