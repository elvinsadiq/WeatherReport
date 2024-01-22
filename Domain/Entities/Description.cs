using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Description : BaseEntity
    {
        public string Introduction {  get; set; }
        public List<DescriptionImage>? DescriptionImages { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
