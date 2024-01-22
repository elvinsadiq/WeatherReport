using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DescriptionImage : BaseEntity
    {
        public string Image { get; set; }
        public int DescriptionId { get; set; }
        public Description Description { get; set; }
    }
}
