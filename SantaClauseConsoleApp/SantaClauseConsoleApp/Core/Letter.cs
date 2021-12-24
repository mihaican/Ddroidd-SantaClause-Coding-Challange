using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaClauseConsoleApp
{
    public class Letter
    {
        public Letter(int id, List<Item> gitf_list)
        {
            Id = id;
            Gifts = gitf_list.ToList();  
        }
        public int Id { get; set; }

        public List<Item> Gifts;
    }
}
