namespace Bank.Core.Entity
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Bank> Banks { get; set; }  
    }
}
