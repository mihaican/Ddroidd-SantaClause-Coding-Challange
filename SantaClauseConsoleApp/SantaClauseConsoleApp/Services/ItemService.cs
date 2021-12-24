using SantaClauseConsoleApp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SantaClauseConsoleApp.Services
{
    sealed class ItemService
    {
        private ItemRepo _repo;
        private static ItemService instance = null;

        private ItemService(ItemRepo repo)
        {
            _repo = repo;
        }

        public static ItemService Instance(ItemRepo repo)
        {

            if (instance == null)
            {
                instance = new ItemService(repo);
            }
            return instance;

        }
        public void Add(string name)
        {
            var existing = _repo.FindItem(name);
            if (existing == null)
            {
                int id = _repo.GetLastId() + 1;
                Item x = new(name);
                _repo.Add(x);
            }
            else
            {
                IncrementCounter(existing);
            }

        }

        public IOrderedEnumerable<KeyValuePair<string, int>> GenerateReport()   //had to swich to IOrderdEnum because dict cant be ordered
        {
            var res = _repo.GenerateReport();
            var ordered = from entry in res orderby entry.Value descending select entry;
            return ordered;
        }
        public void IncrementCounter(Item item)
        {
            _repo.IncrementCounter(item);
        }

        public Item GetRandom()
        {
            return _repo.GetRandom();
        }
    }
}
