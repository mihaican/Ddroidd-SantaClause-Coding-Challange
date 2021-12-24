using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClauseConsoleApp.Repository
{
    sealed class ChildRepo
    {
        public List<Child> ChildList = new();
        private static ChildRepo instance = null;

        public static ChildRepo Instance()
        {

            if (instance == null)
            {
                instance = new ChildRepo();
            }
            return instance;

        }
        public void Add(Child x)
        {
            ChildList.Add(x);
        }
        public int GetLastId()
        {
            if (ChildList.Count == 0)
                return 0;
            else
                return ChildList.LastOrDefault().Id;
        }

        public Child GetPos(int x)
        {
            return ChildList[x];
        }

        public void ChildExists(string name)
        {
            foreach(var item in ChildList)
            {
                if (item.Name == name)
                    throw new InvalidOperationException("Child already exists");
            }
        }

        public void RemoveAll()
        {
            ChildList = new List<Child>();
        }

        public List<Child> getList()
        {
            return ChildList;
        }

        public Dictionary<string,List<string>> GenerateItinerary()
        {
            Dictionary<string, List<string> > results = new();
            foreach (var item in ChildList)
            {
                if (results.ContainsKey(item.Address.City))
                    results[item.Address.City].Add(item.Address.Street +" No "+ item.Address.Number);
                else
                {
                    results.Add(item.Address.City, new List<string>());
                    results[item.Address.City].Add(item.Address.Street +" No " + item.Address.Number);
                }
                    
            }
            return results;
        }
    }
}
