using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Dto
{
    public class StudentDto
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Dob { get; set; }
        public decimal Gpa { get; set; }
    }
}
