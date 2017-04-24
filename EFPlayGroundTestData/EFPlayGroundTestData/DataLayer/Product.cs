namespace EFPlayGroundTestData.DataLayer
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
 
        public virtual Category Category { get; set; }
    }
}