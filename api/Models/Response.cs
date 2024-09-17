using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Response
    {
        [Key]
        public int ResponseID { get; set; }
        public DateTime BeginDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        

        public int UserId { get; set; }
    }
}