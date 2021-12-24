using SantaClauseConsoleApp.Core;
using SantaClauseConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClauseConsoleApp.Services
{
    class LetterService
    {
        private LetterRepo _repo;
        private ItemService _item_service;
        private static LetterService instance = null;
        private LetterService (LetterRepo repo, ItemService service)
        {
            _repo = repo;
            _item_service = service;           
      
        }

        public static LetterService Instance(LetterRepo repo, ItemService service)
        {

            if (instance == null)
            {
                instance = new LetterService(repo, service);
            }
            return instance;
        }

            public void Add(List <Item> gift_list)
            {
                int id = _repo.GetLastId() + 1;
                foreach(var item in gift_list)
                {
                    _item_service.Add(item.Name);
                }
                Letter x = new(id,gift_list);
                _repo.Add(x);
            }

        public string ReadLetter(string fileName)
        {
            return System.IO.File.ReadAllText(fileName);
        } 
        public void SendLetter(string name,string text)
        {
            string path = @"../../../Letters/" + name+".txt";
            System.IO.File.WriteAllText(path, text);
        }

        public Tuple<string,int,Address,List<Item>,bool> DeserializeLetter(string text)  
        {
            text = text.Replace("\r", "");  //Deals with inconsistent line endings
            var lines = text.Split("\n");

            string name = propertyFromLetterString(lines[1],"I am ");
            var sentences = lines[2].Split(".");
            int age = Int32.Parse(propertyFromLetterString(sentences[0],"I am ","years old"));
            string address_string = propertyFromLetterString(sentences[1],"I live at ");
            string city = propertyFromLetterString(address_string,null, ",");
            string street = propertyFromLetterString(address_string, ",", " No");
            int number = Int32.Parse(propertyFromLetterString(address_string, "No"));
            string behaviour = propertyFromLetterString(sentences[2], "I have been a very", "child this year");
            behaviour=behaviour.Replace(" ", "");
            bool nice = false;
            if (behaviour == "nice")
                nice = true;
            Address address = new(city, street, number);
            var items = lines[4].Split(",");
            var list = new List<Item>();
            foreach (string i in items)
            {
                var gift = new Item(i);
                list.Add(gift);

            }
            return Tuple.Create(name, age, address, list,nice);

        }
        private string propertyFromLetterString(string text,string start_str, string end_str=null)
        {
            var start = 0;
            if (start_str == null)
                start = 0;
            else
                start = text.IndexOf(start_str) + start_str.Length;
            var end=0;
            if (end_str != null)
                end = text.IndexOf(end_str);
            else
                end = text.Length;
            return text[start..end];
        }
        public Letter GetLatestLetter()
        {
            return _repo.GetLatestLetter();
        }

        public string SerializeLetter(Child child)
        {
            string text = "Dear Santa,\nI am " + child.Name +
                        "\nI am " + child.Age + " years old"+
                        ". I live at " + child.Address +
                        ". I have been a very " + (child.IsNice ? "nice" : "not nice") + " child this year" +
                        "\nWhat I would like the most this Christmas is:\n";
            var i = 0;
            foreach (var item in child.Letter.Gifts)
            {
                if (i == child.Letter.Gifts.Count - 1)
                    text += item.Name;
                else
                    text += item.Name + ",";
                i++;
            }
            return text;
        }
    }
}
