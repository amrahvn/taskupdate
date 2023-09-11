namespace LastBackProje.Models
{
    public class ProductTag:BaseEntity
    {
        public int ProductID { get; set; }

        public Product Product { get; set; }

        public int TagID { get; set; }

        public Tag Tag { get; set; }
    }
}
