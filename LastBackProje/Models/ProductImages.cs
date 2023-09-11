namespace LastBackProje.Models
{
    public class ProductImages:BaseEntity
    {
        public string Image { get; set; }


        public int productID { get; set; }

        public Product Product { get; set; }
    }
}
