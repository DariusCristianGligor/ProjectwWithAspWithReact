using Domain.NormalDomain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ReviewDto
    {
        public int Stars { get; set; }
        public Price CostOfPlace { get; set; }
        public Guid PlaceId { get; set; }
        public string Description { get; set; }
        public List<IFormFile> Image { get; set; }
      
    }
}
