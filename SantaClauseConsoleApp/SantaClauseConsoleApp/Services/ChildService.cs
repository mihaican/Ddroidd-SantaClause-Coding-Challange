using SantaClauseConsoleApp.Core;
using SantaClauseConsoleApp.Repository;
using System;
using System.Collections.Generic;

namespace SantaClauseConsoleApp.Services
{
    sealed class ChildService
    {
        private ChildRepo _repo;
        private static ChildService instance = null;
        private ChildService(ChildRepo repo)
        {
            _repo = repo;
        }
        public static ChildService Instance(ChildRepo repo)
        {

            if (instance == null)
            {
                instance = new ChildService(repo);
            }
            return instance;

        }
        public void Add(string name, DateTime date, int age, Address address, Letter letter, bool isNice)
        {
            try
            {
                _repo.ChildExists(name);
                int id = _repo.GetLastId() + 1;
                Child x = new(name, date, age, address, letter, isNice);
                _repo.Add(x);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        public void RemoveAllChildren()
        {
            _repo.RemoveAll();
        }

        public List<Child> GetList()
        {
            return _repo.getList();
        }

        public Dictionary<string, List<string>> GenerateItinerary()
        {
            return _repo.GenerateItinerary();
        }
    }
}
