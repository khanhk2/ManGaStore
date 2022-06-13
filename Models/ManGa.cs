using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManGaStore.Models
{
    public class ManGa
    {
        [Key]
        
        public long ManGaID { get; set; }
        [Required(ErrorMessage = "Please enter a title")]
        [Display(Name = "Tên ManGa")]
        public string Title { get; set; }
        
        [Display(Name = "Thể Loại ManGa")]
        [Required(ErrorMessage = "Please specify a genre")]
        public string Genre { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        [Display(Name = "Giá")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public string ProfilePicture { get; set; }
    }
}
