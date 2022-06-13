using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManGaStore.Models.ViewModels
{
    public class ManGaViewModels
    {
        [Key]
        public long ManGaID { get; set; }
        [Display(Name = "Tên ManGa")]
        public string Title { get; set; }

        [Display(Name = "Thể Loại ManGa")]
        public string Genre { get; set; }
        [Display(Name = "Giá")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public IFormFile ImageManGa { get; set; }
    }
}
