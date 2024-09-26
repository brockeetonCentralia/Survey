using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOS.Question;
using api.Models;

namespace api.Mappers
{
    public  static class QuestionMapper
    {
        public static QuestionDTO ToQuestionDTO(this Question _questionModel){
            return new QuestionDTO {
                QuestionID = _questionModel.QuestionID,
                QuestionText = _questionModel.QuestionText,
                isMandatory = _questionModel.isMandatory,
            };
        }    

        public static Question ToQuestionFromCreateDTO(this CreateQuestionRequestDTO _questionDTO) {
            return new Question {
                QuestionText = _questionDTO.QuestionText,
                isMandatory = _questionDTO.isMandatory,
            };
        }
    }
}