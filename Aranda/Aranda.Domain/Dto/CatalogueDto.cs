using Microsoft.AspNetCore.Http;

namespace Aranda.Domain.Dto
{
    public class CatalogueDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
       public IFormFile Img { get; set; }
    }
}
