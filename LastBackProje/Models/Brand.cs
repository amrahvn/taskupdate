using System.ComponentModel.DataAnnotations;

namespace LastBackProje.Models
{
    public class Brand:BaseEntity
    {
        [StringLength(255)]
        public string Name { get; set; }

        public IEnumerable<Product>? products { get; set; }
    }
}
