using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RalphCMS.Models
{
    public class Page
    {
        [Key]
        [Required]
        public string Title { get; set; }
        [Required]
        public int Index { get; set; }
        [Required]
        public bool AddToNavMenu { get; set; }
        [Required]
        public int Visits { get; set; }
        public string Content { get; set; }
    }
}
