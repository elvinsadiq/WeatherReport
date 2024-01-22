using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductDetails.ProductModelDetail
{
    public class ColorResponse
    {
        public int Id { get; set; }
        public string ColorHexCode { get; set; }
        public List<string>? ImageFiles { get; set; }
    }
}
