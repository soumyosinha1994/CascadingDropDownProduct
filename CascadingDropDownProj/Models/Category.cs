using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CascadingDropDownProj.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Category Name")]
        public string? CategoryName { get; set; }

    }
}
