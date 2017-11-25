using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Classes")]
    public partial class Classes
    {
        public Classes()
        {
            Students = new HashSet<Students>();
        }
        public Guid ClassId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Teacher { get; set; }

        public ICollection<Students> Students { get; set; }
    }
}
