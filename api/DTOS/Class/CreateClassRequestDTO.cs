using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOS.Class
{
    public class CreateClassRequestDTO
    {
        public int ClassCode { get; set;} 
        public string ClassName { get; set; } = string.Empty;
        public string InstructorName { get; set; } =  string.Empty;
    }
}