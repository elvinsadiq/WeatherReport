using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductDescriptionDetails.Queries.Response
{
    public class GetByIdProductDescriptionQueryResponse
    {
        public int Id { get; set; }
        public string Introduction { get; set; }
        public List<string>? ImageFiles { get; set; }
    }
}
