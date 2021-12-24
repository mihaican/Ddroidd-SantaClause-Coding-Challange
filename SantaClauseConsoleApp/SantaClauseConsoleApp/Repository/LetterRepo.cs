using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClauseConsoleApp.Repository
{
    class LetterRepo
    {
        public List<Letter> LetterList = new();
        private static LetterRepo instance = null;

        public static LetterRepo Instance()
        {

            if (instance == null)
            {
                instance = new LetterRepo();
            }
            return instance;

        }
        public void Add(Letter x)
        {
            LetterList.Add(x);
        }
        public int GetLastId()
        {
            if (LetterList.Count == 0)
                return 0;
            else
                return LetterList.LastOrDefault().Id;
        }

        public Letter GetPos(int x)
        {
            return LetterList[x];
        }
        internal Letter GetLatestLetter()
        {
            return LetterList.LastOrDefault();
        }
    }
}
