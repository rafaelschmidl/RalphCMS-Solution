using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public bool IsInNavMenu { get; set; } = true;
        [Required]
        public int Visits { get; set; } = 0;
        public string Content { get; set; }
    }
}