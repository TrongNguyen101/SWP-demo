using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;}
        [Required]
        [StringLength(40)]
        public string Name { get; set;}
        public double Price { get; set;}
        public ICollection<Product> products { get; set;}
    }
}