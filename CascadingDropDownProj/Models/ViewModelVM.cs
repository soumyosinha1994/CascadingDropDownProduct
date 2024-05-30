using Microsoft.AspNetCore.Mvc.Rendering;
using Mono.TextTemplating;
using System.Diagnostics.Metrics;

namespace CascadingDropDownProj.Models
{
    public class ViewModelVM
    {
        public Category? Category { get; set; }
        public SubCategory? SubCategory { get; set; }
        public Product? Product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
