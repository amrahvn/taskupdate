using System.ComponentModel.DataAnnotations;

namespace LastBackProje.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(255)]
        public string CreatedBy { get; set; } = "System";

        public DateTime CreatedDate { get; set;}=DateTime.Now;

        [StringLength(255)]
        public string? UpdatedBy { get; set; }

        public Nullable<DateTime> UpdatedDate { get; set; }

        [StringLength(255)]
        public string? DeletedBy { get; set; }

        public Nullable<DateTime> DeletedDate { get; set;}

    }
}
