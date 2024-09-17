using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOS.Class;
using api.Models;
namespace api.Mappers
{
    public static class ClassMapper
    {
        public static ClassDTO ToClassDTO(this Classes _classModel){
            return new ClassDTO {
                ClassID = _classModel.ClassID,
                ClassCode = _classModel.ClassCode,
                ClassName = _classModel.ClassName,
                InstructorName = _classModel.InstructorName
            };
        }    

        public static Classes ToClassFromCreateDTO(this CreateClassRequestDTO _classDTO) {
            return new Classes {
                ClassCode = _classDTO.ClassCode,
                ClassName = _classDTO.ClassName,
                InstructorName = _classDTO.InstructorName
            };
        }
    }
}