using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadingDropDownProj.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Sub-Category Name")]
        public string? SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
