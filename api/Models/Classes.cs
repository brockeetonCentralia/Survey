using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Classes
    {
        [Key]
        public int ClassID { get; set; }
        [Required]
        public int ClassCode { get; set; }
        [Required]
        public string ClassName { get; set; } = string.Empty;
        [Required]
        public string InstructorName { get; set; } =  string.Empty;
    }
}