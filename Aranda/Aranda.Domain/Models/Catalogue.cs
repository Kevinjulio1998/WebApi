using System;

namespace Aranda.Domain.Models
{
    public class Catalogue
    {
        public Guid Id { get; set; }
        public Catalogue() => Id = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Img { get; set; }
    }
}
