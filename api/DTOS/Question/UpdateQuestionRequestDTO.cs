using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOS.Question
{
    public class UpdateQuestionRequestDTO
    {
        public string QuestionText { get; set; } = string.Empty;
        public int isMandatory { get; set; }
    }
}