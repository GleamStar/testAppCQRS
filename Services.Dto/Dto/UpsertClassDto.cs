using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.Dto
{
    public class UpsertClassDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        [RegularExpression("^(Miss|Mr|Mrs|Ms) ([A-Z])([a-z]+)")]
        public string Teacher { get; set; }
    }
}
