using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Students")]
    public partial class Students
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Dob { get; set; }
        public decimal Gpa { get; set; }
        public Guid ClassId { get; set; }

        public Classes Class { get; set; }
    }
}
