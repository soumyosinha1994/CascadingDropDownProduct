using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadingDropDownProj.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public string? ProductName { get; set; }
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public SubCategory? SubCategory { get; set; }
    }
}
