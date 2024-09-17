using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Survey
    {
        [Key]
        public int SurveyID { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public int MinResponse { get; set; }
        public int MaxResponse { get; set; }

        public int ClassId { get; set; }
    }
}