using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClauseConsoleApp.Repository
{
    class ItemRepo
    {
        public List<Item> ItemList=new();
        private static ItemRepo instance = null;

        public static ItemRepo Instance()
        {

            if (instance == null)
            {
                instance = new ItemRepo();
            }
            return instance;

        }
        public void Add(Item x)
        {
            ItemList.Add(x);
        }
        public int GetLastId()
        {
            if (ItemList.Count == 0)
                return 0;
            else
                return ItemList.LastOrDefault().Id;
        }

        public Item FindItem(string name)
        {
            return ItemList.Find(item => item.Name == name);
        }

        public Item GetRandom()
        {
            var random = new Random();
            return ItemList[random.Next(ItemList.Count)];
        }

        public void IncrementCounter(Item item)
        {
            foreach (var i in ItemList)
                if (i.Name == item.Name)
                    i.RequestCnt++;
        }

        public Dictionary<string,int> GenerateReport()
        {
            Dictionary<string, int> results = new();

            foreach(var item in ItemList)
            {
                results.Add(item.Name, item.RequestCnt);
            }      

            return results;
        }
    }
}
