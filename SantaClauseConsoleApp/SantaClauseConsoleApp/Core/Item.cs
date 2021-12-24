namespace SantaClauseConsoleApp
{
    public class Item
    {
        public Item(string name)
        {
            Name = name;
            RequestCnt = 1; //if it was created it means there is at least one request for it
        }
        public int Id { get; set;}
        public string Name { get; set; }

        public int RequestCnt { get; set; }
        
    }
}
