using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Dto
{
    public class ClassDto
    {
        public Guid ClassId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Teacher { get; set; }
    }
}
