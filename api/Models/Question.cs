using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public int isMandatory { get; set; }

        public int SurveyId { get; set; }
        public int ResponseId { get; set; }
        public int QuestionTypeId { get; set; }
    }
}